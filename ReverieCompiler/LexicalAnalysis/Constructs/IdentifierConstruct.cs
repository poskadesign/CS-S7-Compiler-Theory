// 
//   IdentifierConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System.Diagnostics.Contracts;

namespace Reverie.LexicalAnalysis.Constructs {
    public class IdentifierConstruct : IConstruct {

        public IdentifierConstruct(string name) {
            Contract.Requires(!string.IsNullOrEmpty(name));

            Name = name;
        }

        public string Name { get; }
    }
}