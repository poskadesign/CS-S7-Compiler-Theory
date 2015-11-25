// 
//   Compiler.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-09
//   

#define VERBOSE

using System;
using Reverie.Exceptions;
using Reverie.LexicalAnalysis;
using Reverie.SyntaxProcessing;
using Reverie.Traits;

namespace Reverie {
    /// <summary>
    /// Encapsulates every step of the compilation process
    /// </summary>
    public static class Compiler {
        /// <summary>
        /// Translates a Reverie compilation unit into assembly code
        /// </summary>
        /// <param name="source">Compilation unit input</param>
        /// <returns>Assembly instruction listing</returns>
        public static object CompileUnit(string source) {
#if VERBOSE
            Console.WriteLine("Reverie Compiler\nAuthor Vilius Poška. 2015\n");
            Console.WriteLine($"Translating input:\n\n{source}\n");
#endif
            try {

                #region 1. Syntax Processing
                var tokens = new Scanner().IdentifyTokens(source);
#if VERBOSE
                Console.WriteLine("Phase 1 (scanner) results:\n");
                tokens.ForEach(Console.WriteLine);
#endif
                #endregion

                #region 2. Lexical Analysis

                tokens.RemoveAll(t => t.Type == Token.IGNORABLE);
                var processedTokens = new Lexer().ProcessTokens(tokens);

                #endregion

            } catch (ScannerException e) {
                Console.WriteLine($"{e.Message}\n\nCompilation process has been terminated.");
                return null;
            }
            catch (LexerException e) {
                Console.WriteLine($"{e.Message}\n\nCompilation process has been terminated.");
                return null;
            }
            return null;
        }
    }
}