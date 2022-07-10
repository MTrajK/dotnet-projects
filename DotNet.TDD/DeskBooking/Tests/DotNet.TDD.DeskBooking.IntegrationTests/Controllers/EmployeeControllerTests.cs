namespace DotNet.TDD.DeskBooking.IntegrationTests.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;

    using DotNet.TDD.DeskBooking.IntegrationTests.Setup;
    using DotNet.TDD.DeskBooking.API;
    using DotNet.TDD.DeskBooking.IntegrationTests.Utils;
    using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;

    public class EmployeeControllerTests : IClassFixture<TestInMemoryWebApplicationFactory<Startup>>
    {
        private static HttpClient _sut;

        private const string _addEmployeeUri = "/api/Employee/Add";
        private const string _getEmployeeUri = "/api/Employee/Get?id={0}";

        public EmployeeControllerTests(TestInMemoryWebApplicationFactory<Startup> factory)
        {
            _sut = factory.CreateClient();
        }

        [Fact]
        public async Task Add_SomeEmployee_ReturnsSuccess()
        {
            // Arrange
            var employee = new EmployeeRequest()
            {
                Email = "some-employee@mail.com",
                FirstName = "Some",
                LastName = "Employee"
            };
            var httpContentWithEmployee = HttpContentUtils.IncludeDataToHttpContent(employee);

            //Act
            var response = await _sut.PostAsync(_addEmployeeUri, httpContentWithEmployee);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_GetAddedEmployee_ReturnsAddedEmployee()
        {
            // Arrange
            var employee = new EmployeeRequest()
            {
                Email = "added-employee@mail.com",
                FirstName = "Added",
                LastName = "Employee"
            };
            var httpContentWithEmployee = HttpContentUtils.IncludeDataToHttpContent(employee);

            var addedEmployeeResponse = await _sut.PostAsync(_addEmployeeUri, httpContentWithEmployee);
            var addedEmployeeId = await addedEmployeeResponse.Content.ReadAsInt();

            var getEmployeeUri = string.Format(_getEmployeeUri, addedEmployeeId);

            //Act
            var response = await _sut.GetAsync(getEmployeeUri);

            // Assert
            var responseValue = await response.Content.ReadAsDTO<EmployeeRequest>();
            responseValue.Should().BeEquivalentTo(employee);
        }
    }
}
