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
        public static bool IsPartialMatch(string input, string pattern)
            => IsMatch(input, @"\A(?:" + pattern + @")");

        public static Match PartialMatch(string input, string pattern)
            => Match(input, @"\A(?:^" + pattern + @")");
    }
}