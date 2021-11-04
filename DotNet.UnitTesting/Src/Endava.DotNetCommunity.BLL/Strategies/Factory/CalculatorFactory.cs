using Endava.DotNetCommunity.Common.Exceptions;

namespace Endava.DotNetCommunity.BLL.Strategies.Factory
{
    public class CalculatorFactory : IStrategyFactory
    {
        public IStrategy GetStrategy(string operation)
        {
            return operation switch
            {
                "+" => new AdditionStrategy(),
                "-" => new SubtractionStrategy(),
                "*" => new MultiplicationStrategy(),
                _ => throw new NotFoundOperationException(string.Format("Operation '{0}' doesn't exists.", operation)),
            };
        }
    }
}
