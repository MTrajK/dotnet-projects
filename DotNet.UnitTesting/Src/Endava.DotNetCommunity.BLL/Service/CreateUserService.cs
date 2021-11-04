using Endava.DotNetCommunity.BLL.IService;
using Endava.DotNetCommunity.BLL.Strategies.Context;
using Endava.DotNetCommunity.BLL.Strategies.Factory;
using Endava.DotNetCommunity.Common.APIModels;
using Endava.DotNetCommunity.Common.Utils;
using Endava.DotNetCommunity.DAL.IPersistence;

namespace Endava.DotNetCommunity.BLL.Service
{
    public class CreateUserService : ICreateUserService
    {
        private IUserPersistence _persistance;
        private IStrategyFactory _strategyFactory;
        private IStrategyContext _strategyContext;

        public CreateUserService(IUserPersistence persistance, IStrategyFactory strategyFactory, IStrategyContext strategyContext)
        {
            _persistance = persistance;
            _strategyFactory = strategyFactory;
            _strategyContext = strategyContext;
        }

        public CreateUserResponseModel CreateUser(CreateUserRequestModel request)
        {
            var strategy = _strategyFactory.GetStrategy(request.Operation);

            _strategyContext.SetStrategy(strategy);
            var result = _strategyContext.ExecuteStrategy(request.Number1, request.Number2);

            var fileName = _persistance.CreateUser(request.ToDomainModel(result));

            return new CreateUserResponseModel(fileName);
        }
    }
}
