// 
//   TokenExpression.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//   

namespace Reverie.Traits {
    /// <summary>
    /// Pairs a token type to its respective expression
    /// </summary>
    public struct TokenExpression {
        public TokenExpression(LanguageToken token, string expression) {
            Token = token;
            Expression = expression;
        }
        public LanguageToken Token;
        public string Expression;
    }
}