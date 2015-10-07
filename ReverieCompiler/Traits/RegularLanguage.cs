// 
//   RegularLanguage.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//

using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Pattern = System.String;

namespace Reverie.Traits {
    /// <summary>
    /// Defines all regular language tokens
    /// </summary>
    public enum LanguageToken
    {
        // whitespace
        INDENT,
        NEW_LINE,
        // operators
        OP_ADDITION,
        OP_DIVISION,
        OP_EXPONENT,
        OP_SUBTRACTION,
        OP_MODULO,
        OP_MULTIPLICATION,
        // reserved keywords
        KW_FUNC,
        KW_RETURN,
        // reserved symbols
        RE_L_PAREN,
        RE_R_PAREN,
        RE_COMMA,

        IDENTIFIER,

        SEPARATOR
    }

    /// <summary>
    /// Defines basic type traits and low level validation.
    /// </summary>
    public static class RegularLanguage {

        /// <summary>
        /// Maps language tokens to their respective regular expression patterns
        /// </summary>
        public static IDictionary<LanguageToken, Pattern> TokenPatterns = new Dictionary<LanguageToken, Pattern> {
            [LanguageToken.INDENT] = @"(\t)|(\s{4})",
            [LanguageToken.NEW_LINE] = @"(\n)|(\r)",

            [LanguageToken.OP_ADDITION] = @"(\+)",
            [LanguageToken.OP_DIVISION] = @"(/)",
            [LanguageToken.OP_EXPONENT] = @"(\^)",
            [LanguageToken.OP_SUBTRACTION] = @"(-)",
            [LanguageToken.OP_MODULO] = @"(%)",
            [LanguageToken.OP_MULTIPLICATION] = @"(\*)",

            [LanguageToken.RE_L_PAREN] = @"\(",
            [LanguageToken.RE_R_PAREN] = @"\)",
            [LanguageToken.RE_COMMA] = @"\,",

            [LanguageToken.KW_FUNC] = @"(func)[^\w\d]|(func)\z",
            [LanguageToken.KW_RETURN] = @"(ret)[^\w\d]|(ret)\z",

            [LanguageToken.IDENTIFIER] = @"([$a-zA-Z_][$\w]*)",

            [LanguageToken.SEPARATOR] = @"\s"
        };
    }
}