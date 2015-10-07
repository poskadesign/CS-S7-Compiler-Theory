// 
//   Scanner.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//   

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using Reverie.Traits;
using Reverie.Utilities;
using CaptureType = System.String;

namespace Reverie {
    public class Scanner {

        [Pure]
        public Dictionary<LanguageToken, CaptureType> IdentifyTokens(string input) {
            var resolvedLength = 0;
            var column = 1;
            var row = 1;
            while (input.Length > 0) {
                var token = IdentifyFirstToken(input);
                if (token.HasValue)
                    input = input.Substring(token.Value.Value.Length);
                else
                    Debugger.Break();
            }
            return null;
        }

        private static KeyValuePair<LanguageToken, string>? IdentifyFirstToken(string input) {
            foreach (var token in RegularLanguage.TokenPatterns) {
                var match = RegexExtensions.PartialMatch(input, token.Value);
                if (match.Captures.Count > 0)
                    return new KeyValuePair<LanguageToken, string>(token.Key, match.Captures[0].Value);
            }
            return null;
        }
    }
}