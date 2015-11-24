// 
//   Lexer.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Reverie.Exceptions;
using Reverie.LexicalAnalysis.Constructs;
using Reverie.LexicalAnalysis.Extensions;
using Reverie.SyntaxProcessing.Constructs;
using Reverie.Traits;

namespace Reverie.LexicalAnalysis {
    public sealed class Lexer {

        private IList<ResolvedToken> Tokens { get; set; }

        public ProgramConstruct ProcessTokens(IList<ResolvedToken> tokens) {
            Contract.Requires(tokens != null);

            Tokens = tokens;
            IList<FunctionConstruct> functions = new List<FunctionConstruct>();

            while (Tokens.Any()) {
                switch (Tokens.First().Type) {
                    case Token.KW_FUNC:
                        functions.Add(ProcessAsFunction());
                        break;
                    case Token.NEW_LINE:

                        break;

                    default:

                        break;
                }
            }

            //var token = tokens.First();


            return null;
        }

        private FunctionConstruct ProcessAsFunction() {


            return null;
        }

        private ResolvedToken GetNextToken(ResolvedToken expected) {
            return Tokens.FirstWithAssert(expected, new LexerException(ErrorCode.ErrorForCode("LEX1"), expected, Tokens.First(), "Unexpected token encountered"));
        }

    }
}