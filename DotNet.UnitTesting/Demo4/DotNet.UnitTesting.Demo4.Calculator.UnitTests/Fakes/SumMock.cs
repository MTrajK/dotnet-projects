using DotNet.UnitTesting.Demo4.Calculator.Operations;

namespace DotNet.UnitTesting.Demo4.CalculatorUnitTests.Fakes
{
    public class SumMock : IOperation
    {
        public int CallsCount { get; private set; } = 0;

        public int Execute(int a, int b)
        {
            CallsCount++;

            return 3;
        }
    }
}
