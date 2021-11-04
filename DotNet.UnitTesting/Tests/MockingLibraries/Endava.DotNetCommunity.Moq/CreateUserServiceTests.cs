using Endava.DotNetCommunity.BLL.Service;
using Endava.DotNetCommunity.BLL.Strategies;
using Endava.DotNetCommunity.BLL.Strategies.Context;
using Endava.DotNetCommunity.BLL.Strategies.Factory;
using Endava.DotNetCommunity.Common.APIModels;
using Endava.DotNetCommunity.Common.DomainModels;
using Endava.DotNetCommunity.Common.Exceptions;
using Endava.DotNetCommunity.Common.Utils;
using Endava.DotNetCommunity.DAL.IPersistence;
using Moq;
using NUnit.Framework;
using System;

namespace Endava.DotNetCommunity.Moq
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

            var mockStrategyFactory = new Mock<IStrategyFactory>();
            mockStrategyFactory
                .Setup(x => x.GetStrategy(requestModel.Operation))
                .Returns(additionStrategy);

            var mockStrategyContext = new Mock<IStrategyContext>();
            mockStrategyContext
                .Setup(x => x.SetStrategy(additionStrategy));
            mockStrategyContext
                .Setup(x => x.ExecuteStrategy(requestModel.Number1, requestModel.Number2))
                .Returns(domainModel.Result);

            var mockPersistence = new Mock<IUserPersistence>();
            mockPersistence
                .Setup(x => x.CreateUser(It.Is<UserModel>(y => domainModel.DeepCompare(y))))
                .Returns(responseModel.FileName);

            var sut = 
                new CreateUserService(mockPersistence.Object, mockStrategyFactory.Object, mockStrategyContext.Object);

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

            var mockStrategyFactory = new Mock<IStrategyFactory>();
            mockStrategyFactory
                .Setup(x => x.GetStrategy(It.IsAny<string>()));

            var mockStrategyContext = new Mock<IStrategyContext>();
            mockStrategyContext
                .Setup(x => x.SetStrategy(It.IsAny<IStrategy>()));
            mockStrategyContext
                .Setup(x => x.ExecuteStrategy(It.IsAny<int>(), It.IsAny<int>()));

            var mockPersistence = new Mock<IUserPersistence>();
            mockPersistence
                .Setup(x => x.CreateUser(It.IsAny<UserModel>()))
                .Returns(responseModel.FileName);

            var sut =
                new CreateUserService(mockPersistence.Object, mockStrategyFactory.Object, mockStrategyContext.Object);

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

            var mockStrategyFactory = new Mock<IStrategyFactory>();
            var mockStrategyContext = new Mock<IStrategyContext>();

            var mockPersistence = new Mock<IUserPersistence>();
            mockPersistence
                .Setup(x => x.CreateUser(It.IsAny<UserModel>()))
                .Returns(responseModel.FileName);

            var sut =
                new CreateUserService(mockPersistence.Object, mockStrategyFactory.Object, mockStrategyContext.Object);

            // Act
            sut.CreateUser(requestModel);

            // Assert
            mockStrategyFactory.Verify(x => x.GetStrategy(It.IsAny<string>()), Times.Once);
            mockStrategyContext.Verify(x => x.SetStrategy(It.IsAny<IStrategy>()), Times.Once);
            mockStrategyContext.Verify(x => x.ExecuteStrategy(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockPersistence.Verify(x => x.CreateUser(It.IsAny<UserModel>()), Times.Once);
            mockPersistence.VerifyNoOtherCalls();
        }

        [Test]
        public void CreateUser_VerifySequence_Success()
        {
            // Arrange
            var requestModel =
                new CreateUserRequestModel("Meto", "Trajkovski", "meto.trajkovski@mail.com", 10, 15, "+");
            var responseModel =
                new CreateUserResponseModel("User_9a7e8574-c9e4-4ea3-ac2b-ead798bff5b8.json");

            var sequence = new MockSequence();

            var mockStrategyFactory = new Mock<IStrategyFactory>(MockBehavior.Strict);
            mockStrategyFactory
                .InSequence(sequence)
                .Setup(x => x.GetStrategy(It.IsAny<string>()))
                .Returns(new AdditionStrategy());

            var mockStrategyContext = new Mock<IStrategyContext>(MockBehavior.Strict);
            mockStrategyContext
                .InSequence(sequence)
                .Setup(x => x.SetStrategy(It.IsAny<IStrategy>()));
            mockStrategyContext
                .InSequence(sequence)
                .Setup(x => x.ExecuteStrategy(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(25);

            var mockPersistence = new Mock<IUserPersistence>(MockBehavior.Strict);
            mockPersistence
                .InSequence(sequence)
                .Setup(x => x.CreateUser(It.IsAny<UserModel>()))
                .Returns(responseModel.FileName);

            var sut =
                new CreateUserService(mockPersistence.Object, mockStrategyFactory.Object, mockStrategyContext.Object);

            // Act
            sut.CreateUser(requestModel);
        }

        [Test]
        public void CreateUser_StrategyFactoryThrowsException_NotFoundOperationException()
        {
            // Arrange
            var requestModel =
                new CreateUserRequestModel("Meto", "Trajkovski", "meto.trajkovski@mail.com", 10, 15, "+");

            var mockStrategyFactory = new Mock<IStrategyFactory>();
            mockStrategyFactory
                .Setup(x => x.GetStrategy(It.IsAny<string>()))
                .Returns(() => throw new NotFoundOperationException());
                //Or .Throws<NotFoundOperationException>();

            var mockStrategyContext = new Mock<IStrategyContext>();
            var mockPersistence = new Mock<IUserPersistence>();

            var sut =
                new CreateUserService(mockPersistence.Object, mockStrategyFactory.Object, mockStrategyContext.Object);

            // Act & Assert
            TestDelegate action = () => sut.CreateUser(requestModel);
            Assert.Throws<NotFoundOperationException>(action);
        }
    }
}
