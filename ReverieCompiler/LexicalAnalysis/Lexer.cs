// 
//   Lexer.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Reverie.Exceptions;
using Reverie.LexicalAnalysis.Constructs;
using Reverie.LexicalAnalysis.Constructs.Interfaces;
using Reverie.LexicalAnalysis.Extensions;
using Reverie.SyntaxProcessing.Constructs;
using Reverie.Traits;

namespace Reverie.LexicalAnalysis {
    public sealed class Lexer {

        private IList<ResolvedToken> _tokens;
        private int _indentation;

        public ProgramConstruct ProcessTokens(IList<ResolvedToken> tokens) {
            Contract.Requires(tokens != null);

            _tokens = tokens;
            var functions = new List<FunctionConstruct>();
            ExectuableBlockConstruct block = null;

            while (_tokens.Any()) {
                switch (PeekNextToken()) {

                    case Token.KW_FUNC:
                        functions.Add(ProcessAsFunction());
                        break;

                    case Token.EOL:
                        GetNextToken();
                        break;

                    default:
                        block = ProcessAsBlock();
                        break;

                }
            }


            return new ProgramConstruct(functions, block);
        }

        private FunctionConstruct ProcessAsFunction() {

            GetNextTokenAsserted(Token.KW_FUNC);

            var name = new IdentifierConstruct(GetNextTokenAsserted(Token.IDENTIFIER).Capture);
            
            // parse parameters
            var parameters = new List<IdentifierConstruct>();

            GetNextTokenAsserted(Token.RE_L_PAREN);
            while (PeekNextToken() != Token.RE_R_PAREN) {
                switch (PeekNextToken()) {

                    case Token.IDENTIFIER:
                        if (PeekNextToken(1) != Token.RE_R_PAREN && PeekNextToken(1) != Token.RE_COMMA)
                            throw new LexerException(ErrorCode.ErrorForCode("LEX1"), Token.RE_R_PAREN, PeekNextToken(1));
                        parameters.Add(new IdentifierConstruct(GetNextToken().Capture));
                        break;

                    case Token.RE_COMMA:
                        if (PeekNextToken(1) != Token.IDENTIFIER)
                            throw new LexerException(ErrorCode.ErrorForCode("LEX1"), Token.IDENTIFIER, PeekNextToken(1));
                        GetNextToken();
                        break;

                    default:
                        throw new LexerException(ErrorCode.ErrorForCode("LEX1"), Token.IDENTIFIER, PeekNextToken());
                }

            }
            GetNextTokenAsserted(Token.RE_R_PAREN);
            GetNextTokenAsserted(Token.RE_COLON);
            SkipNewLines();
            
            return new FunctionConstruct(name, parameters, ProcessAsBlock());
        }



        private ExectuableBlockConstruct ProcessAsBlock() {
            var expressions = new List<IExecutableConstruct>();
            _indentation++;

            while (IsExecutionInSameBlock(_indentation)) {
                SkipTokensAsserted(Token.INDENT, _indentation);

                expressions.Add(ProcessAsExpression());
                SkipNewLines();
            }



            Contract.Ensures(Contract.Result<ExectuableBlockConstruct>() != null);
            return new ExectuableBlockConstruct(expressions);
        }

        private IExecutableConstruct ProcessAsExpression() {
            var firstToken = PeekNextToken();
            var secondToken = PeekNextToken(1);

            switch (PeekNextToken()) {

                case Token.IDENTIFIER:
                    if (firstToken == Token.IDENTIFIER && secondToken == Token.OP_ASSIGNMENT)
                        return ProcessAsAssignment();
                    if (firstToken == Token.IDENTIFIER && secondToken == Token.RE_L_PAREN)
                        return ProcessAsFunctionCall();
                    throw new LexerException(ErrorCode.ErrorForCode("LEX1"), Token.RE_L_PAREN, secondToken);

                case Token.KW_RETURN:
                    return ProcessAsFunctionReturn();

                default:
                    throw new LexerException(ErrorCode.ErrorForCode("LEX1"), Token.IDENTIFIER, secondToken);

            }
        }

        private AssignmentOperatorConstruct ProcessAsAssignment() {
            var lhs = new VariableConstruct(new IdentifierConstruct(GetNextTokenAsserted(Token.IDENTIFIER).Capture));
            SkipTokensAsserted(Token.OP_ASSIGNMENT);
            return new AssignmentOperatorConstruct(lhs, ProcessAsRvalue());
        }

        private IRvalueConstruct ProcessAsRvalue() {

            var members = new List<object>();
            var endOfExpression = false;

            while (!endOfExpression) {

                endOfExpression = true;
                switch (PeekNextToken()) {

                    case Token.INTEGER:
                        members.Add(ParseIntegerConstruct());
                        break;

                    case Token.REAL:
                        throw new NotImplementedException();

                    case Token.IDENTIFIER:
                        if (PeekNextToken(1) == Token.RE_L_PAREN)
                            members.Add(ProcessAsFunctionCall());
                        else
                            members.Add(ProcessAsVariableConstruct());
                        break;

                    default:
                        throw new LexerException(ErrorCode.ErrorForCode("LEX1"), Token.RE_L_PAREN, PeekNextToken());
                }

                switch (PeekNextToken()) {
                    case Token.OP_ADDITION:
                    case Token.OP_DIVISION:
                    case Token.OP_EXPONENT:
                    case Token.OP_MODULO:
                    case Token.OP_MULTIPLICATION:
                    case Token.OP_SUBTRACTION:
                        members.Add(GetNextToken());
                        endOfExpression = false;
                        break;
                    default:
                        break;
                }

            }
            return PolishNotation.InfixToPrefix(members);
        }


        private IRvalueConstruct ParseIntegerConstruct() {
            var value = int.Parse(GetNextTokenAsserted(Token.INTEGER).Capture);
            return new IntegerConstruct(value);
        }

        private FunctionCallConstruct ProcessAsFunctionCall() {
            throw new NotImplementedException();
        }

        private FunctionReturnConstruct ProcessAsFunctionReturn() {
            GetNextTokenAsserted(Token.KW_RETURN);
            return new FunctionReturnConstruct(ProcessAsRvalue());
        }

        private VariableConstruct ProcessAsVariableConstruct() {
            return new VariableConstruct(new IdentifierConstruct(GetNextTokenAsserted(Token.IDENTIFIER).Capture));
        }


        #region Helper Methods

        private void SkipNewLines() {
            while(_tokens.First()?.Type == Token.EOL)
                    _tokens.RemoveAt(0);
        }

        private bool IsExecutionInSameBlock(int indentLevel)
            => _tokens.Take(indentLevel).All(t => t.Type == Token.INDENT);

        private ResolvedToken GetNextToken() {
            var first = _tokens.FirstOrDefault();

            if (first == null)
                throw new LexerException(ErrorCode.ErrorForCode("LEX2"));

            _tokens.RemoveAt(0);
            return first;
        }

        private ResolvedToken GetNextTokenAsserted(Token expected) {
            var first = _tokens.FirstOrDefault();

            if (first == null)
                throw new LexerException(ErrorCode.ErrorForCode("LEX2"));
            if (first.Type != expected)
                throw new LexerException(ErrorCode.ErrorForCode("LEX1"), expected, first.Type);

            _tokens.RemoveAt(0);
            return first;
        }

        private void SkipTokensAsserted(Token expected, int count = 1) {
            Contract.Requires(count > 0);

            var subset = _tokens.Take(count).ToArray();

            if (subset.Any(t => t.Type != expected))
                throw new LexerException(ErrorCode.ErrorForCode("LEX1"), expected, subset.Last().Type);

            for (var i = 0; i < count; i++)
                _tokens.RemoveAt(0);

        }

        private void SkipTokens(int count = 1) {
            Contract.Requires(count > 0);

            for (var i = 0; i < count; i++)
                _tokens.RemoveAt(0);

        }

        private Token PeekNextToken(int count = 0) {
            if (_tokens.Count <= count)
                throw new LexerException(ErrorCode.ErrorForCode("LEX2"));

            return _tokens.Skip(count).First().Type;
        }

        #endregion

    }
}