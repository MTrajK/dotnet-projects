using AutoFixture.NUnit3;
using Endava.DotNetCommunity.BLL.Service;
using Endava.DotNetCommunity.Common.APIModels;
using Endava.DotNetCommunity.Common.DomainModels;
using Endava.DotNetCommunity.DAL.IPersistence;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Endava.DotNetCommunity.FluentAssertions
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
