// 
//   ErrorCode.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-08
//   

using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Reverie.Exceptions {
    public class ErrorCode {
        public string Code;
        public string Message;

        public ErrorCode(string code, string message) {
            Code = code;
            Message = message;
        }

        public override string ToString() => $"{Code}: {Message}";

        [Pure]
        public static ErrorCode ErrorForCode(string code) {
            if (!ErrorCodes.ContainsKey(code.ToUpper()))
                return new ErrorCode("0", "Invalid error code");
            var result = ErrorCodes[code];
            return new ErrorCode(code, result);
        }

        private static readonly Dictionary<string, string> ErrorCodes = new Dictionary<string, string> {
            // syntax processor exceptions
            ["SCA1"] = "Uknown token encountered",

            // lexical analyser exceptions
            ["LEX1"] = "Unexpected token encountered",
            ["LEX2"] = "Unexpected end of token sequence"
        };
    }
}