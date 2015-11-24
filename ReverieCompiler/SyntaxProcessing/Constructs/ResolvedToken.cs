// 
//   ResolvedToken.cs
//   ReverieCompiler
//   
//   Created by Vilius Poška
//   2015-10-08
//   

using Reverie.Traits;
using System.Text.RegularExpressions;

namespace Reverie.SyntaxProcessing.Constructs {
    public class ResolvedToken {
        public ResolvedToken(Token type, string capture, int row, int column) {
            Type = type;
            Capture = capture;
            Row = row;
            Column = column;
        }

        public override string ToString() => $"{Type}: (\"{Regex.Escape(Capture)}\"), Col: {Column}, Row: {Row}";

        public Token Type { get; set; }
        public string Capture { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}