// 
//   IntegerConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-28
// 

using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class IntegerConstruct : IRvalueConstruct {
        public IntegerConstruct(int value) {
            Value = value;
        }

        private int Value { get; }

        public override string ToString() => Value.ToString();
    }
}