// 
//   ProgramConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Reverie.LexicalAnalysis.Constructs {
    public class ProgramConstruct : IConstruct {

        public ProgramConstruct(IEnumerable<FunctionConstruct> functions, ExectuableBlockConstruct block) {
            Contract.Requires(functions != null);
            Contract.Requires(block != null);

            Functions = functions;
            Block = block;
        }

        public IEnumerable<FunctionConstruct> Functions { get; }
        public ExectuableBlockConstruct Block { get; }
    }
}