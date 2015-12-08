// 
//   InfixOperatorConstruct.cs
//   ReverieCompiler.Compiler
// 
//   Created By Vilius Poška
//   2015-11-24
// 

using Reverie.LexicalAnalysis.Constructs.Interfaces;

namespace Reverie.LexicalAnalysis.Constructs {
    public class AdditionConstruct : IInfixOperatorConstruct {

        public AdditionConstruct(IRvalueConstruct operand1, IRvalueConstruct operand2) {
            Operand1 = operand1;
            Operand2 = operand2;
        }

        public IRvalueConstruct Operand1 { get; }
        public IRvalueConstruct Operand2 { get; }

        public override string ToString() => $"{Operand1} + {Operand2}";
    }

    public class MultiplicationConstruct : IInfixOperatorConstruct
    {

        public MultiplicationConstruct(IRvalueConstruct operand1, IRvalueConstruct operand2)
        {
            Operand1 = operand1;
            Operand2 = operand2;
        }

        public IRvalueConstruct Operand1 { get; }
        public IRvalueConstruct Operand2 { get; }

        public override string ToString() => $"{Operand1} * {Operand2}";
    }

    public class SubtractionConstruct : IInfixOperatorConstruct
    {

        public SubtractionConstruct(IRvalueConstruct operand1, IRvalueConstruct operand2)
        {
            Operand1 = operand1;
            Operand2 = operand2;
        }

        public IRvalueConstruct Operand1 { get; }
        public IRvalueConstruct Operand2 { get; }

        public override string ToString() => $"{Operand1} - {Operand2}";
    }

    public class DivisionConstruct : IInfixOperatorConstruct
    {

        public DivisionConstruct(IRvalueConstruct operand1, IRvalueConstruct operand2)
        {
            Operand1 = operand1;
            Operand2 = operand2;
        }

        public IRvalueConstruct Operand1 { get; }
        public IRvalueConstruct Operand2 { get; }

        public override string ToString() => $"{Operand1} / {Operand2}";
    }

    public class ModuloConstruct : IInfixOperatorConstruct
    {

        public ModuloConstruct(IRvalueConstruct operand1, IRvalueConstruct operand2)
        {
            Operand1 = operand1;
            Operand2 = operand2;
        }

        public IRvalueConstruct Operand1 { get; }
        public IRvalueConstruct Operand2 { get; }

        public override string ToString() => $"{Operand1} % {Operand2}";
    }

    public class ExponentConstruct : IInfixOperatorConstruct
    {

        public ExponentConstruct(IRvalueConstruct operand1, IRvalueConstruct operand2)
        {
            Operand1 = operand1;
            Operand2 = operand2;
        }

        public IRvalueConstruct Operand1 { get; }
        public IRvalueConstruct Operand2 { get; }

        public override string ToString() => $"{Operand1} ^ {Operand2}";
    }

}