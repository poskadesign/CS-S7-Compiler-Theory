// 
//   RegexExtensions.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-05
//   

using System.Text.RegularExpressions;

namespace Reverie.Utilities {
    public class RegexExtensions : Regex {
        public static bool IsPartialMatch(string input, string expression)
            => IsMatch(input, @"\A(?:" + expression + @")");
    }
}