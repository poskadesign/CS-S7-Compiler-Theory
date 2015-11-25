// 
//   FunctionCallConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-25
// 

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class FunctionCallConstruct : IRvalueConstruct, IExecutableConstruct {

        public FunctionCallConstruct(IdentifierConstruct callee, IList<IRvalueConstruct> parameters) {
            Contract.Requires(callee != null);
            Contract.Requires(parameters != null);

            Callee = callee;
            Parameters = parameters;
        }

        private IdentifierConstruct Callee { get; }
        private IList<IRvalueConstruct> Parameters { get; }
    }
}