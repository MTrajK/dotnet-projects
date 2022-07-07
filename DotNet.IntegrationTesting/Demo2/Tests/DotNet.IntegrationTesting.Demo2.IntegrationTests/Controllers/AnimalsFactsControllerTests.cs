namespace DotNet.IntegrationTesting.Demo2.IntegrationTests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using DotNet.IntegrationTesting.Demo2.API;
    using DotNet.IntegrationTesting.Demo2.IntegrationTests.Setup;

    [TestClass]
    public class AnimalsFactsControllerTests
    {
        private static HttpClient _sut;

        private const string _randomCatFactUri = "/api/AnimalsFacts/GetRandomCatFact?maxLength={0}";

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            var factory = new TestWebApplicationFactory<Startup>();
            _sut = factory.CreateClient();
        }

        [TestMethod]
        public async Task GetRandomCatFact_MaxLength50Characters_ReturnsFactWith20Characters()
        {
            // Arrange
            var maxLength = 50;
            var uri = string.Format(_randomCatFactUri, maxLength);
            var expectedValue = "Cats have 3 eyelids.";

            //Act
            var response = await _sut.GetAsync(uri);

            // Assert
            var responseValue = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedValue, responseValue);
        }
    }
}
