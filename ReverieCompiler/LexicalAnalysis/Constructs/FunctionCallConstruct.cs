// 
//   FunctionCallConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-25
// 

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
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

        public override string ToString() => $"{Callee}({Parameters.Select(p => p.ToString()).Aggregate((a, b) => a + ", " + b)})";
    }
}