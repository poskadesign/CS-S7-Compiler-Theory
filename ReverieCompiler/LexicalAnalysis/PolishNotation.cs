// 
//   PolishNotation.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-26
// 

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Reverie.Exceptions;
using Reverie.LexicalAnalysis.Constructs;
using Reverie.LexicalAnalysis.Constructs.Interfaces;
using Reverie.SyntaxProcessing.Constructs;
using Reverie.Traits;
using RL = Reverie.Traits.RegularLanguage;

namespace Reverie.LexicalAnalysis {
    public static class PolishNotation {
        public static IRvalueConstruct InfixToPrefix(ICollection<object> construct) {

            if (construct.Count == 1)
                return construct.First() as IRvalueConstruct;

            var output = new Stack<object>();
            var operators = new Stack<object>();

            // separate rvalues and operators
            foreach (var c in construct) {
                if (c is IRvalueConstruct)
                    output.Push(c);
                else if (c is ResolvedToken) {
                    if (operators.Any() && RL.OperatorPrecedence((c as ResolvedToken).Type) < RL.OperatorPrecedence((operators.Peek() as ResolvedToken).Type)) {
                        Merge(output, operators);
                    }
                    operators.Push(c);
                }

            }

            // merge to prefix notation
            Merge(output, operators);

            return Dimensionalize(output);

        }

        private static IRvalueConstruct Dimensionalize(Stack<object> stack) {
            Contract.Requires(stack.Any());

            var next = stack.Pop();
            if (next is IRvalueConstruct)
                return next as IRvalueConstruct;
            if (next is ResolvedToken) {
                switch ((next as ResolvedToken).Type) {
                    case Token.OP_ADDITION:
                        return new AdditionConstruct(Dimensionalize(stack), Dimensionalize(stack));
                    case Token.OP_DIVISION:
                        return new DivisionConstruct(Dimensionalize(stack), Dimensionalize(stack));
                    case Token.OP_EXPONENT:
                        return new ExponentConstruct(Dimensionalize(stack), Dimensionalize(stack));
                    case Token.OP_SUBTRACTION:
                        return new SubtractionConstruct(Dimensionalize(stack), Dimensionalize(stack));
                    case Token.OP_MODULO:
                        return new ModuloConstruct(Dimensionalize(stack), Dimensionalize(stack));
                    case Token.OP_MULTIPLICATION:
                        return new MultiplicationConstruct(Dimensionalize(stack), Dimensionalize(stack));
                    default:
                        throw new LexerException(ErrorCode.ErrorForCode("LEX3"));
                }
            }
            throw new LexerException(ErrorCode.ErrorForCode("LEX3"));
        }

        private static void Merge(Stack<object> destination, Stack<object> source) {
            while (source.Any())
                destination.Push(source.Pop());
        }
    }
}