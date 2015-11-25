// 
//   AssignmentOperatorConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-25
// 

using System.Diagnostics.Contracts;
using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class AssignmentOperatorConstruct : IExecutableConstruct {

        public AssignmentOperatorConstruct(ILvalueConstruct lhs, IRvalueConstruct rhs) {
            Contract.Requires(lhs != null);
            Contract.Requires(rhs != null);

            Lhs = lhs;
            Rhs = rhs;
        }

        private ILvalueConstruct Lhs { get; } 
        private IRvalueConstruct Rhs { get; }
    }
}