// 
//   ResolvedToken.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-08
//   

using System.Text.RegularExpressions;
using Reverie.Traits;

namespace Reverie.SyntaxProcessing {
    public struct ResolvedToken {
        public ResolvedToken(Token type, string capture, int row, int column) {
            Type = type;
            Capture = capture;
            Row = row;
            Column = column;
        }

        public override string ToString() => $"{Type}: (\"{Regex.Escape(Capture)}\"), Col: {Column}, Row: {Row}";

        public Token Type;
        public string Capture;
        public int Row;
        public int Column;
    }
}