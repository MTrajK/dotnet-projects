using DotNet.UnitTesting.Demo4.Calculator.Operations;

namespace DotNet.UnitTesting.Demo4.CalculatorUnitTests.Fakes
{
    public class SumStub : IOperation
    {
        public int Execute(int a, int b)
        {
            return 3;
        }
    }
}
