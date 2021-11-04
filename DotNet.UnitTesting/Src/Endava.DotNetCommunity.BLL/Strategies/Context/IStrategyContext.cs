namespace Endava.DotNetCommunity.BLL.Strategies.Context
{
    public interface IStrategyContext
    {
        public void SetStrategy(IStrategy strategy);

        public int ExecuteStrategy(int number1, int number2);
    }
}
