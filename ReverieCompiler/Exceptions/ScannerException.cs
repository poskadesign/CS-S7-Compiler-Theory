// 
//   ScannerException.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-08
//   

using System;
using System.Linq;
using Reverie.Traits;

namespace Reverie.Exceptions {
    public sealed class ScannerException : Exception {
        public ScannerException(ErrorCode e, int col = 0, int row = 0, string codeFragment = "", string details = "")
            : base(FormatMessage(e, col, row, codeFragment, details)) {}

        private static string FormatMessage(ErrorCode e, int col, int row, string codeFragment, string details) {
            var result = $"\nError {e.Code}: {e.Message}";
            if (col != 0 && row != 0) {
                result += $" At line {row} column {col}.\n{codeFragment.Split('\n')[row - 1]}\n";
                for (var i = 0; i < col-1; i++)
                    result += ' ';
                result += '^';
            }
            return $"{result}\n{details}";
        }
    }
}