// 
//   LexerException.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System;
using Reverie.Traits;

namespace Reverie.Exceptions {
    public sealed class LexerException : Exception {

        public LexerException(ErrorCode e, string details = "") :
            base($"{e}\n{details}.") { }

        public LexerException(ErrorCode e, Token expected, Token encountered, string details = "")
            : base(FormatMessage(e, expected, encountered, details)) { }

        private static string FormatMessage(ErrorCode e, Token expected, Token encountered, string details) {
           return $"{e}\n{details}. Expected token: \"{expected}\", encountered: \"{encountered}\".";
        }

    }
}