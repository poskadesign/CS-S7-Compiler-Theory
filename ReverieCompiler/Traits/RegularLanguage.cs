// 
//   RegularLanguage.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Reverie.Traits {
    /// <summary>
    ///     Defines basic type traits and low level validation.
    /// </summary>
    public static class RegularLanguage {

        /// <summary>
        /// Defines all regular language tokens
        /// </summary>
        public enum Token {
            // Whitespace
            INDENT,
            NEW_LINE,
            // Operators
            ADDITION,
            DIVISION,
            EXPONENT,
            SUBTRACTION,
            MODULO,
            MULTIPLICATION,
        }

        /// <summary>
        /// Maps language tokens to their respective regular expressions
        /// </summary>
        public static Dictionary<Token, string> TokenExpressions = new Dictionary<Token, string>() {
            // Whitespace
            [Token.INDENT] = @"(\t)|(\s{4})",
            [Token.NEW_LINE] = @"(\n)|(\r)",
            // Operators
            [Token.ADDITION] = @"(\+)",
            [Token.DIVISION] = @"(/)",
            [Token.EXPONENT] = @"(\^)",
            [Token.SUBTRACTION] = @"(-)",
            [Token.MODULO] = @"(%)",
            [Token.MULTIPLICATION] = @"(\*)",
        };
    }
}