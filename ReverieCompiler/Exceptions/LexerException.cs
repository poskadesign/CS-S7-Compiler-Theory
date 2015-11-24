// 
//   LexerException.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System;
using Reverie.SyntaxProcessing.Constructs;

namespace Reverie.Exceptions {
    public sealed class LexerException : Exception {
        public LexerException(ErrorCode e, ResolvedToken expected, ResolvedToken encountered, string details = "")
            : base(FormatMessage(e, expected, encountered, details)) { }

        private static string FormatMessage(ErrorCode e, ResolvedToken expected, ResolvedToken encountered, string details) {
           return $"{e}\n{details}. Expected token: \"{expected}\", encountered: \"{encountered}\".";
        }

    }
}