// 
//   ProgramConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class ProgramConstruct : IConstruct {

        public ProgramConstruct(ICollection<FunctionConstruct> functions, ExectuableBlockConstruct block) {
            Contract.Requires(functions != null);
            Contract.Requires(block != null);

            Functions = functions;
            Block = block;
        }

        public ICollection<FunctionConstruct> Functions { get; }
        public ExectuableBlockConstruct Block { get; }
    }
}