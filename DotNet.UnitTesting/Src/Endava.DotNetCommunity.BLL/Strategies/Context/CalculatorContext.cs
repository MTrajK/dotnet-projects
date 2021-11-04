using Endava.DotNetCommunity.Common.Exceptions;

namespace Endava.DotNetCommunity.BLL.Strategies.Context
{
    public class CalculatorContext : IStrategyContext
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public int ExecuteStrategy(int number1, int number2)
        {
            if (_strategy == null)
                throw new MissingStrategyException("The context is missing a strategy instance."); 

            return _strategy.Execute(number1, number2);
        }
    }
}
