namespace DotNet.UnitTestingFrameworks.BLL.Strategies.Factory
{
    public interface IStrategyFactory
    {
        public IStrategy GetStrategy(string operation);
    }
}
