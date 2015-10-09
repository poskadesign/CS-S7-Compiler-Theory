// 
//   RegularLanguage.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//

using System.Collections.Generic;
using Pattern = System.String;

namespace Reverie.Traits {
    /// <summary>
    /// Defines all regular language tokens
    /// </summary>
    public enum Token
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
        // user defined symbols
        IDENTIFIER,
        // type traits
        INTEGER,
        // whitespace and separation
        SEPARATOR
    }

    /// <summary>
    /// Defines basic type traits and low level validation.
    /// </summary>
    public static class RegularLanguage {

        /// <summary>
        /// Maps language tokens to their respective regular expression patterns
        /// </summary>
        public static IDictionary<Token, Pattern> TokenPatterns = new Dictionary<Token, Pattern> {
            [Token.INDENT] = @"(\t)|(\s{4})",
            [Token.NEW_LINE] = @"(\n)|(\r)",

            [Token.OP_ADDITION] = @"(\+)",
            [Token.OP_DIVISION] = @"(/)",
            [Token.OP_EXPONENT] = @"(\^)",
            [Token.OP_SUBTRACTION] = @"(-)",
            [Token.OP_MODULO] = @"(%)",
            [Token.OP_MULTIPLICATION] = @"(\*)",

            [Token.RE_L_PAREN] = @"\(",
            [Token.RE_R_PAREN] = @"\)",
            [Token.RE_COMMA] = @"\,",

            [Token.KW_FUNC] = @"(func)|(func)\z",
            [Token.KW_RETURN] = @"(ret)|(ret)\z",

            [Token.INTEGER] = @"(\d+)",

            [Token.IDENTIFIER] = @"([$a-zA-Z_][$\w]*)",

            [Token.SEPARATOR] = @"\s+"
        };
    }
}