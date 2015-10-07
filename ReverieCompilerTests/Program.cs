using System.Text.RegularExpressions;
using Reverie.Traits;

namespace Reverie.Tests {
    internal class Program {
        private static void Main(string[] args) {
            TestBasicTypeExtensions();
            var p = @"(def)";
            var i = @"deffeningnx";
            var match = Regex.Match(i, p);
        }

        private static void TestBasicTypeExtensions() {
            //RegularLanguage.IsNumber("0").Test();
            //RegularLanguage.IsNumber("567").Test();
            //(!RegularLanguage.IsNumber("A")).Test();
        }
    }
}