namespace DotNet.UnitTestingFrameworks.BLL.Strategies
{
    public class SubtractionStrategy : IStrategy
    {
        public int Execute(int number1, int number2)
        {
            return number1 - number2;
        }
    }
}
