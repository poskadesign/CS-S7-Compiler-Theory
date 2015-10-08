// 
//   Scanner.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//   

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using Reverie.Exceptions;
using Reverie.Traits;
using Reverie.Utilities;

namespace Reverie.Processing {
    public class Scanner {

        [Pure]
        public List<ResolvedToken> IdentifyTokens(string input) {
            int column = 1, row = 1;
            var result = new List<ResolvedToken>();
            // if there is still input left
            while (input.Length > 0) {
                var token = IdentifyFirstToken(input);
                // if token is valid
                if (token.HasValue) {
                    var t = token.Value;
                    result.Add(new ResolvedToken(t.Key, t.Value, row, column));
                    // update caret position
                    input = input.Substring(token.Value.Value.Length);
                    column += t.Value.Length;

                    if (t.Key != Token.NEW_LINE) continue;
                    row++;
                    column = 1;
                }
                else
                    throw new ScannerException(ErrorCode.ErrorForCode("SCA1"));
            }
            return result;
        }

        private static KeyValuePair<Token, string>? IdentifyFirstToken(string input) {
            foreach (var token in RegularLanguage.TokenPatterns) {
                var match = RegexExtensions.PartialMatch(input, token.Value);
                if (match.Captures.Count > 0)
                    return new KeyValuePair<Token, string>(token.Key, match.Captures[0].Value);
            }
            return null;
        }
    }
}