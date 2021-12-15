using DotNet.UnitTestingFrameworks.BLL.IService;
using DotNet.UnitTestingFrameworks.BLL.Strategies.Context;
using DotNet.UnitTestingFrameworks.BLL.Strategies.Factory;
using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.Common.Utils;
using DotNet.UnitTestingFrameworks.DAL.IPersistence;

namespace DotNet.UnitTestingFrameworks.BLL.Service
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
