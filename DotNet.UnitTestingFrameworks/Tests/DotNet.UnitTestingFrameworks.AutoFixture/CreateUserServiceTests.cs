using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.NUnit3;
using DotNet.UnitTestingFrameworks.BLL.Service;
using DotNet.UnitTestingFrameworks.BLL.Strategies.Context;
using DotNet.UnitTestingFrameworks.BLL.Strategies.Factory;
using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.Common.DomainModels;
using DotNet.UnitTestingFrameworks.Common.Utils;
using DotNet.UnitTestingFrameworks.DAL.IPersistence;
using NSubstitute;
using NUnit.Framework;

namespace DotNet.UnitTestingFrameworks.AutoFixture
{
    [TestFixture]
    public class CreateUserServiceTests
    {
        private static IFixture _fixture;

        [OneTimeSetUp]
        public void ClassInitialze()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        }

        [Test]
        public void CreateUser_Step1Start_Success()
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

            // Assert
            Assert.IsTrue(responseModel.DeepCompare(result));
        }

        [Test]
        public void CreateUser_Step2GenerateData_Success()
        {
            // Arrange
            var requestModel = _fixture.Create<CreateUserRequestModel>();
            var responseModel = _fixture.Create<CreateUserResponseModel>();

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

            // Assert
            Assert.IsTrue(responseModel.DeepCompare(result));
        }

        [Test]
        public void CreateUser_Step3GenerateMocks_Success()
        {
            // Arrange
            var requestModel = _fixture.Create<CreateUserRequestModel>();
            var responseModel = _fixture.Create<CreateUserResponseModel>();

            var mockStrategyFactory = _fixture.Freeze<IStrategyFactory>();
            var mockStrategyContext = _fixture.Freeze<IStrategyContext>();

            var mockPersistence = _fixture.Freeze<IUserPersistence>();
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
        public void CreateUser_Step4GenerateSut_Success()
        {
            // Arrange
            var requestModel = _fixture.Create<CreateUserRequestModel>();
            var responseModel = _fixture.Create<CreateUserResponseModel>();

            var mockPersistence = _fixture.Freeze<IUserPersistence>();
            mockPersistence
                .CreateUser(Arg.Any<UserModel>())
                .Returns(responseModel.FileName);

            var sut = _fixture.Create<CreateUserService>();

            // Act
            var result = sut.CreateUser(requestModel);

            // Assert
            Assert.IsTrue(responseModel.DeepCompare(result));
        }

        [Theory]
        [AutoNSubstituteData]
        public void CreateUser_Step5AutoNSubstituteData_Success(
            [Frozen] IUserPersistence mockPersistence, CreateUserRequestModel requestModel,
            CreateUserResponseModel responseModel, CreateUserService sut)
        {
            // Arrange
            mockPersistence
                .CreateUser(Arg.Any<UserModel>())
                .Returns(responseModel.FileName);

            // Act
            var result = sut.CreateUser(requestModel);

            // Assert
            Assert.IsTrue(responseModel.DeepCompare(result));
        }
    }
}
