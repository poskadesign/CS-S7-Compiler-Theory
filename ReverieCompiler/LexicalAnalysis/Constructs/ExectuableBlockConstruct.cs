// 
//   ExectuableBlockConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class ExectuableBlockConstruct : IConstruct {

        public ExectuableBlockConstruct(ICollection<IExecutableConstruct> expressions) {
            Contract.Requires(expressions != null);

            Expressions = expressions;
        }

        private ICollection<IExecutableConstruct> Expressions { get; }
    }
}