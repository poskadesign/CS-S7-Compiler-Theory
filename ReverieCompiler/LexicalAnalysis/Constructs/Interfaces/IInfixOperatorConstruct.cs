// 
//   IInfixOperatorConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-12-08
// 

namespace Reverie.LexicalAnalysis.Constructs.Interfaces {
    public interface IInfixOperatorConstruct : IRvalueConstruct {
        IRvalueConstruct Operand1 { get; }
        IRvalueConstruct Operand2 { get; }
    }
}