using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Reverie.Traits;
using Reverie.Utilities;

namespace Reverie.Tests {
    internal class Program {
        private static void Main(string[] args) {
            TestBasicTypeExtensions();
            TestScanner();
            TestFuncKeywordExpression();
            
        }

        private static void TestBasicTypeExtensions() {
            //RegularLanguage.IsNumber("0").Test();
            //RegularLanguage.IsNumber("567").Test();
            //(!RegularLanguage.IsNumber("A")).Test();
        }

        private static void TestFuncKeywordExpression() {
            var i = "func\nsum(a, b)\n\tret 0";
            var match = RegexExtensions.PartialMatch(i, RegularLanguage.TokenPatterns[LanguageToken.KW_FUNC]);
            Console.WriteLine(match?.Captures[0]);
            Debugger.Break();
            (match.Captures.Count != 1).Test();
        }

        private static void TestScanner() {
            var s = new Scanner();
            var res = s.IdentifyTokens("func sum(a, b)\n\treturn a+b\n\nsum(2, 4)");
            Debugger.Break();
        }
    }
}