// 
//   FunctionConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Contracts;
using Reverie.LexicalAnalysis.Constructs.Interfaces;
using Reverie.SyntaxProcessing.Constructs;

namespace Reverie.LexicalAnalysis.Constructs {
    public class FunctionConstruct : IConstruct {

        public FunctionConstruct(IdentifierConstruct name, ICollection<IdentifierConstruct> parameters, ExectuableBlockConstruct controlBlock) {
            Contract.Requires(name != null);
            Contract.Requires(parameters != null);
            Contract.Requires(controlBlock != null);

            Name = name;
            Parameters = parameters;
            ControlBlock = controlBlock;

        }

        public IdentifierConstruct Name { get; }
        public ICollection<IdentifierConstruct>  Parameters { get; }
        public ExectuableBlockConstruct ControlBlock { get; }

        public override string ToString() => $"{Name}({Parameters.Select(p => p.ToString()).Aggregate((a, b) => a + ", " + b)})";

    }
}