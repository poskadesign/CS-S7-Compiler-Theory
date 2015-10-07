// 
//   LanguageToken.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//   

namespace Reverie.Traits {
    /// <summary>
    /// Defines all regular language tokens
    /// </summary>
    public enum LanguageToken {
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
}