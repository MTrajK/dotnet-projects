using DotNet.UnitTestingFrameworks.BLL.Service;
using DotNet.UnitTestingFrameworks.BLL.Strategies;
using DotNet.UnitTestingFrameworks.BLL.Strategies.Context;
using DotNet.UnitTestingFrameworks.BLL.Strategies.Factory;
using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.Common.DomainModels;
using DotNet.UnitTestingFrameworks.Common.Exceptions;
using DotNet.UnitTestingFrameworks.Common.Utils;
using DotNet.UnitTestingFrameworks.DAL.IPersistence;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace DotNet.UnitTestingFrameworks.NSubstitute
{
    [TestFixture]
    public class CreateUserServiceTests
    {
        [Test]
        public void CreateUser_MockServicesWithValues_Success()
        {
            // Arrange
            var requestModel =
                new CreateUserRequestModel("Meto", "Trajkovski", "meto.trajkovski@mail.com", 10, 15, "+");
            var domainModel =
                new UserModel("Meto", "Trajkovski", "meto.trajkovski@mail.com", 10, 15, "+", 25);
            var responseModel =
                new CreateUserResponseModel("User_9a7e8574-c9e4-4ea3-ac2b-ead798bff5b8.json");
            var additionStrategy = new AdditionStrategy();

            var mockStrategyFactory = Substitute.For<IStrategyFactory>();
            mockStrategyFactory
                .GetStrategy(requestModel.Operation)
                .Returns(additionStrategy);

            var mockStrategyContext = Substitute.For<IStrategyContext>();
            mockStrategyContext
                .SetStrategy(additionStrategy);
            mockStrategyContext
                .ExecuteStrategy(requestModel.Number1, requestModel.Number2)
                .Returns(domainModel.Result);

            var mockPersistence = Substitute.For<IUserPersistence>();
            mockPersistence
                .CreateUser(Arg.Is<UserModel>(y => domainModel.DeepCompare(y)))
                .Returns(responseModel.FileName);

            var sut =
                new CreateUserService(mockPersistence, mockStrategyFactory, mockStrategyContext);

            // Act
            var result = sut.CreateUser(requestModel);

            // Assert
            Assert.IsTrue(responseModel.DeepCompare(result));
        }

        [Test]
        public void CreateUser_MockServicesAnyValues_Success()
        {
            // Arrange
            var requestModel =
                new CreateUserRequestModel("Meto", "Trajkovski", "meto.trajkovski@mail.com", 10, 15, "+");
            var responseModel =
                new CreateUserResponseModel("User_9a7e8574-c9e4-4ea3-ac2b-ead798bff5b8.json");

            var mockStrategyFactory = Substitute.For<IStrategyFactory>();
            mockStrategyFactory
                .GetStrategy(Arg.Any<string>());

            var mockStrategyContext = Substitute.For<IStrategyContext>();
            mockStrategyContext
                .SetStrategy(Arg.Any<IStrategy>());
            mockStrategyContext
                .ExecuteStrategy(Arg.Any<int>(), Arg.Any<int>());

            var mockPersistence = Substitute.For<IUserPersistence>();
            mockPersistence
                .CreateUser(Arg.Any<UserModel>())
                .Returns(responseModel.FileName);

            var sut =
                new CreateUserService(mockPersistence, mockStrategyFactory, mockStrategyContext);

            // Act
            var result = sut.CreateUser(requestModel);

            // Assert
            Assert.IsTrue(responseModel.DeepCompare(result));
        }

        [Test]
        public void CreateUser_VerifyCalls_Success()
        {
            // Arrange
            var requestModel =
                new CreateUserRequestModel("Meto", "Trajkovski", "meto.trajkovski@mail.com", 10, 15, "+");
            var responseModel =
                new CreateUserResponseModel("User_9a7e8574-c9e4-4ea3-ac2b-ead798bff5b8.json");

            var mockStrategyFactory = Substitute.For<IStrategyFactory>();
            var mockStrategyContext = Substitute.For<IStrategyContext>();

            var mockPersistence = Substitute.For<IUserPersistence>();
            mockPersistence
                .CreateUser(Arg.Any<UserModel>())
                .Returns(responseModel.FileName);

            var sut =
                new CreateUserService(mockPersistence, mockStrategyFactory, mockStrategyContext);

            // Act
            sut.CreateUser(requestModel);

            // Assert
            mockStrategyFactory.Received(1).GetStrategy(Arg.Any<string>());
            mockStrategyContext.Received(1).SetStrategy(Arg.Any<IStrategy>());
            mockStrategyContext.Received(1).ExecuteStrategy(Arg.Any<int>(), Arg.Any<int>());
            mockPersistence.Received(1).CreateUser(Arg.Any<UserModel>());
            mockPersistence.DidNotReceive().GetUser(Arg.Any<string>());
        }

        [Test]
        public void CreateUser_VerifySequence_Success()
        {
            // Arrange
            var requestModel =
                new CreateUserRequestModel("Meto", "Trajkovski", "meto.trajkovski@mail.com", 10, 15, "+");
            var responseModel =
                new CreateUserResponseModel("User_9a7e8574-c9e4-4ea3-ac2b-ead798bff5b8.json");

            var mockStrategyFactory = Substitute.For<IStrategyFactory>();
            var mockStrategyContext = Substitute.For<IStrategyContext>();

            var mockPersistence = Substitute.For<IUserPersistence>();
            mockPersistence
                .CreateUser(Arg.Any<UserModel>())
                .Returns(responseModel.FileName);

            var sut =
                new CreateUserService(mockPersistence, mockStrategyFactory, mockStrategyContext);

            // Act
            var result = sut.CreateUser(requestModel);

            // Arrange
            Received.InOrder(() => {
                mockStrategyFactory.GetStrategy(Arg.Any<string>());
                mockStrategyContext.SetStrategy(Arg.Any<IStrategy>());
                mockStrategyContext.ExecuteStrategy(Arg.Any<int>(), Arg.Any<int>());
                mockPersistence.CreateUser(Arg.Any<UserModel>());
            });
        }

        [Test]
        public void CreateUser_StrategyFactoryThrowsException_NotFoundOperationException()
        {
            // Arrange
            var requestModel =
                new CreateUserRequestModel("Meto", "Trajkovski", "meto.trajkovski@mail.com", 10, 15, "+");

            var mockStrategyFactory = Substitute.For<IStrategyFactory>();
            mockStrategyFactory
                .GetStrategy(Arg.Any<string>())
                .Returns(x => throw new NotFoundOperationException());

            var mockStrategyContext = Substitute.For<IStrategyContext>();
            var mockPersistence = Substitute.For<IUserPersistence>();

            var sut =
                new CreateUserService(mockPersistence, mockStrategyFactory, mockStrategyContext);

            // Act & Assert
            TestDelegate action = () => sut.CreateUser(requestModel);
            Assert.Throws<NotFoundOperationException>(action);
        }
    }
}
