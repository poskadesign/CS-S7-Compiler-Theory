// 
//   RegularLanguage.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//

using System.Collections.Generic;
using TE = Reverie.Traits.TokenExpression;

namespace Reverie.Traits {
    /// <summary>
    /// Defines basic type traits and low level validation.
    /// </summary>
    public static class RegularLanguage {
        /// <summary>
        /// Maps language tokens to their respective regular expressions
        /// </summary>
        public static IList<TE> TokenExpressions = new List<TE> {
            // whitespace
            new TE(LanguageToken.INDENT, @"(\t)|(\s{4})"),
            new TE(LanguageToken.NEW_LINE, @"(\n)|(\r)"),
            // operators
            new TE(LanguageToken.ADDITION, @"(\+)"),
            new TE(LanguageToken.DIVISION, @"(/)"),
            new TE(LanguageToken.EXPONENT, @"(\^)"),
            new TE(LanguageToken.SUBTRACTION, @"(-)"),
            new TE(LanguageToken.MODULO, @"(%)"),
            new TE(LanguageToken.MULTIPLICATION, @"(\*)"),
        };
    }
}