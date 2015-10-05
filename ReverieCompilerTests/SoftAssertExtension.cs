using System;
using System.Diagnostics;

namespace Reverie.Tests {
    public static class SoftAssertExtension {
        public static void Test(this bool condition) {
            if (!condition)
                Debugger.Break();
            else {
                Console.WriteLine("[PASS]");
            }
        }
    }
}