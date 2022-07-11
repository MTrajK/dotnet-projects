using DotNet.TDD.DeskBooking.API;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.IntegrationTests.Setup;
using DotNet.TDD.DeskBooking.IntegrationTests.Utils;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DotNet.TDD.DeskBooking.IntegrationTests.Controllers
{
    public class DeskControllerTests : IClassFixture<TestDockerWebApplicationFactory<Startup>>
    {
        private static HttpClient _sut;

        private const string _addDeskUri = "/api/Desk/Add";
        private const string _getDeskUri = "/api/Desk/Get?id={0}";

        public DeskControllerTests(TestDockerWebApplicationFactory<Startup> factory)
        {
            _sut = factory.CreateClient();
        }

        [Fact]
        public async Task Add_SomeDesk_ReturnsSuccess()
        {
            // Arrange
            var desk = new DeskRequest()
            {
                Number = 1,
                Floor = 1,
                Capacity = 4
            };
            var httpContentWithDesk = HttpContentUtils.IncludeDataToHttpContent(desk);

            //Act
            var response = await _sut.PostAsync(_addDeskUri, httpContentWithDesk);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_GetAddedDesk_ReturnsAddedDesk()
        {
            // Arrange
            var desk = new DeskRequest()
            {
                Number = 24,
                Floor = 3,
                Capacity = 8
            };
            var httpContentWithDesk = HttpContentUtils.IncludeDataToHttpContent(desk);

            var addedDeskResponse = await _sut.PostAsync(_addDeskUri, httpContentWithDesk);
            var addedDeskId = await addedDeskResponse.Content.ReadAsLong();

            var getDeskUri = string.Format(_getDeskUri, addedDeskId);

            //Act
            var response = await _sut.GetAsync(getDeskUri);

            // Assert
            var responseValue = await response.Content.ReadAsDTO<DeskRequest>();
            responseValue.Should().BeEquivalentTo(desk);
        }
    }
}
