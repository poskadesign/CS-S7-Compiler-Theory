// 
//   Scanner.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//   

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using Reverie.Traits;
using Reverie.Utilities;

namespace Reverie {
    public class Scanner {

        [Pure]
        public Dictionary<LanguageToken, string> IdentifyTokens(string input) {
            foreach (var token in RegularLanguage.TokenExpressions) {
                if (RegexExtensions.IsPartialMatch(input, token.Expression)) {
                    
                }
            }
            return null;
        }
    }
}