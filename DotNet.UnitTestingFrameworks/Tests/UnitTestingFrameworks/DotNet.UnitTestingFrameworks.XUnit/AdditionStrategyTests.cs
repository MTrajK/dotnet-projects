using Xunit;

namespace DotNet.UnitTestingFrameworks.XUnit
{
    public class AdditionStrategyTests : IClassFixture<AdditionStrategyFixture>
    {
        private AdditionStrategyFixture _testFixture;

        public AdditionStrategyTests(AdditionStrategyFixture testFixture)
        {
            // Method that will be called before each test method present in the class.
            _testFixture = testFixture;
        }

        [Fact]
        public void Execute_Adding3and5_Returns8()
        {
            // Arrange
            var number1 = 3;
            var number2 = 5;
            var expectedResult = 8;

            // Act
            var actualResult = _testFixture.sut.Execute(number1, number2);

            // Assert
            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(5, 7, 12)]
        [InlineData(10, 6, 16)]
        [InlineData(1, -10, -9)]
        public void Execute_AddingNumber1andNumber2_ReturnsExpectedResult(int number1, int number2, int expectedResult)
        {
            // Act
            var actualResult = _testFixture.sut.Execute(number1, number2);

            // Assert
            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
