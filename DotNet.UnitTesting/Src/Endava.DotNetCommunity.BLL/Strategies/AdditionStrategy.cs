namespace Endava.DotNetCommunity.BLL.Strategies
{
    public class AdditionStrategy : IStrategy
    {
        public int Execute(int number1, int number2)
        {
            return number1 + number2;
        }
    }
}
