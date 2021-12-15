namespace DotNet.UnitTesting.Demo4.Calculator.Operations
{
    public class Sum : IOperation
    {
        public int Execute(int a, int b)
        {
            return a + b;
        }
    }
}
