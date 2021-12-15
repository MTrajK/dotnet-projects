using AutoFixture.NUnit3;
using DotNet.UnitTestingFrameworks.BLL.Service;
using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.Common.DomainModels;
using DotNet.UnitTestingFrameworks.DAL.IPersistence;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace DotNet.UnitTestingFrameworks.FluentAssertions
{
    [TestFixture]
    public class CreateUserServiceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void CreateUser_UseFluentAssertionsBeEquivalentTo_Success(
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
            responseModel.Should().BeEquivalentTo(result);
        }
    }
}
