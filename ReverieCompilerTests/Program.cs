using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Reverie.LexicalAnalysis.Extensions;
using Reverie.SyntaxProcessing;
using Reverie.Traits;
using Reverie.Utilities;

namespace Reverie.Tests {
    internal class Program {
        private static void Main(string[] args) {
            TestBasicTypeExtensions();
            TestScanner();
            //TestFuncKeywordExpression();
            
        }

        private static void TestBasicTypeExtensions() {
            //RegularLanguage.IsNumber("0").Test();
            //RegularLanguage.IsNumber("567").Test();
            //(!RegularLanguage.IsNumber("A")).Test();
        }

        private static void TestFuncKeywordExpression() {
            var i = "func\nsum(a, b)\n\tret 0";
            var match = RegexExtensions.PartialMatch(i, RegularLanguage.TokenPatterns[Token.KW_FUNC]);
            Console.WriteLine(match?.Captures[0]);Debugger.Break();
            (match.Captures.Count != 1).Test();
        }

        private static void TestScanner() {
            string testString;
            using (var sr = new StreamReader(@"..\..\SampleFiles\sample3.re")) {
                testString = sr.ReadToEnd();
            }
            Compiler.CompileUnit(testString);
        }
    }
}