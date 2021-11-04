namespace Endava.DotNetCommunity.BLL.Strategies.Factory
{
    public interface IStrategyFactory
    {
        public IStrategy GetStrategy(string operation);
    }
}
