using NUnit.Framework;

namespace DotNet.UnitTestingFrameworks.Mock.Tests
{
    public class MockTests
    {
        [Test]
        public void Setup_MethodAddMatchingParameters_ReturnsMockedReturnValue()
        {
            // Arrange
            var expectedArguments = new object[] { 4, 5 };
            var expectedReturnValue = 9;

            // Act
            var mock = new Mock<ICalculator>();
            mock.Setup("Add", expectedArguments, expectedReturnValue);

            ICalculator mockObject = mock.Object;
            var actualResult = mockObject.Add(4, 5);

            // Assert
            Assert.AreEqual(expectedReturnValue, actualResult);
        }

        [Test]
        public void Setup_MethodAddNonMatchingParameters_ReturnsNull()
        {
            // Arrange
            var expectedArguments = new object[] { 12, 2 };
            var expectedReturnValue = 9;

            // Act
            var mock = new Mock<ICalculator>();
            mock.Setup("Add", expectedArguments, expectedReturnValue);

            ICalculator mockObject = mock.Object;
            var actualResult = mockObject.Add(2, 12);

            // Assert
            Assert.AreEqual(0, actualResult);
        }

        [Test]
        public void Setup_MethodAddToStringMatchingParameters_ReturnsMockedReturnValue()
        {
            // Arrange
            var expectedArguments = new object[] { 1, 2 };
            var expectedReturnValue = "3";

            // Act
            var mock = new Mock<ICalculator>();
            mock.Setup("AddToString", expectedArguments, expectedReturnValue);

            ICalculator mockObject = mock.Object;
            var actualResult = mockObject.AddToString(1, 2);

            // Assert
            Assert.AreEqual(expectedReturnValue, actualResult);
        }

        [Test]
        public void Setup_MethodAddToStringNonMatchingParameters_ReturnsNull()
        {
            // Arrange
            var expectedArguments = new object[] { 43, -2 };
            var expectedReturnValue = "33";

            // Act
            var mock = new Mock<ICalculator>();
            mock.Setup("AddToString", expectedArguments, expectedReturnValue);

            ICalculator mockObject = mock.Object;
            var actualResult = mockObject.AddToString(18, 2);

            // Assert
            Assert.Null(actualResult);
        }
    }
}
