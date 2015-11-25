// 
//   FunctionReturnConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-25
// 

using System.Diagnostics.Contracts;
using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class FunctionReturnConstruct : IExecutableConstruct {

        public FunctionReturnConstruct(IRvalueConstruct rvalue) {
            Contract.Requires(rvalue != null);

            Rvalue = rvalue;
        }

        private IRvalueConstruct Rvalue { get; }
    }
}