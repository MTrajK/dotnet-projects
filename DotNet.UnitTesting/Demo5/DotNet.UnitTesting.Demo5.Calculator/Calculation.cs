using DotNet.UnitTesting.Demo5.Calculator.Operations;

namespace DotNet.UnitTesting.Demo5.Calculator
{
    public class Calculation
    {
        private IOperation _operation;

        public Calculation(IOperation operation)
        {
            _operation = operation;
        }

        public int Execute(int a, int b)
        {
            return _operation.Execute(a, b);
        }
    }
}
