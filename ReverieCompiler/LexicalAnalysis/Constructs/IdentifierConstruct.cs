﻿// 
//   IdentifierConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using System.Diagnostics.Contracts;
using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class IdentifierConstruct : IConstruct {

        public IdentifierConstruct(string name) {
            Contract.Requires(!string.IsNullOrEmpty(name));

            Name = name;
        }

        public string Name { get; }

        public override string ToString() => Name;
    }
}