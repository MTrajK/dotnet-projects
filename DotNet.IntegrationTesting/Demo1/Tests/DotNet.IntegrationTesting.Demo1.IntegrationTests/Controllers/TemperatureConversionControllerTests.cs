namespace DotNet.IntegrationTesting.Demo1.IntegrationTests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using DotNet.IntegrationTesting.Demo1.API;
    using DotNet.IntegrationTesting.Demo1.IntegrationTests.Utils;
    using DotNet.IntegrationTesting.Demo1.IntegrationTests.Setup;

    [TestClass]
    public class TemperatureConversionControllerTests
    {
        private static HttpClient _sut;

        private const string _convertCelsiusToFahrenheitUri = "/api/TemperatureConversion/ConvertCelsiusToFahrenheit?temperature={0}";
        private const string _convertFahrenheitToCelsiusUri = "/api/TemperatureConversion/ConvertFahrenheitToCelsius?temperature={0}";

        [ClassInitialize()]
        public static void ClassInit(TestContext context) {
            var factory = new TestWebApplicationFactory<Startup>();
            _sut = factory.CreateClient();
        }

        [TestMethod]
        public async Task ConvertCelsiusToFahrenheit_Temperature0CelsiusDegrees_Returns32FahrenheitDegrees()
        {
            // Arrange
            var celsiusDegrees = 0;
            var uri = string.Format(_convertCelsiusToFahrenheitUri, celsiusDegrees);
            var expectedValue = 32;

            //Act
            var response = await _sut.GetAsync(uri);

            // Assert
            var responseValue = await response.Content.ReadAsDouble();
            Assert.AreEqual(expectedValue, responseValue);
        }

        [TestMethod]
        public async Task ConvertFahrenheitToCelsius_Temperature32FahrenheitDegrees_Returns0CelsiusDegrees()
        {
            // Arrange
            var fahrenheitDegrees = 32;
            var uri = string.Format(_convertFahrenheitToCelsiusUri, fahrenheitDegrees);
            var expectedValue = 0;

            //Act
            var response = await _sut.GetAsync(uri);

            // Assert
            var responseValue = await response.Content.ReadAsDouble();
            Assert.AreEqual(expectedValue, responseValue);
        }
    }
}
