// 
//   VariableConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-25
// 

using System.Diagnostics.Contracts;
using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class VariableConstruct : ILvalueConstruct, IRvalueConstruct {

        public VariableConstruct(IdentifierConstruct name) {
            Contract.Requires(name != null);

            Name = name;
        }

        private IdentifierConstruct Name { get; }
         
    }
}