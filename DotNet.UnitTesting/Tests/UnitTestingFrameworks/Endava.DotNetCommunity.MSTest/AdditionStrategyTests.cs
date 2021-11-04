using Endava.DotNetCommunity.BLL.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Endava.DotNetCommunity.MSTest
{
    [TestClass]
    public class AdditionStrategyTests
    {
        private static AdditionStrategy _sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Method that will be called only once before executing any of the test methods present in this class.
            _sut = new AdditionStrategy();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Method that will be called only once after executing all of the test methods present in this class.
            _sut = null;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Method that will be called before each test method present in the class.
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Method that will be called after each test method present in the class.
        }

        [TestMethod]
        public void Execute_Adding3and5_Returns8()
        {
            // Arrange
            var number1 = 3;
            var number2 = 5;
            var expectedResult = 8;

            // Act
            var actualResult = _sut.Execute(number1, number2);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow(5, 7, 12)]
        [DataRow(10, 6, 16)]
        [DataRow(1, -10, -9)]
        public void Execute_AddingNumber1andNumber2_ReturnsExpectedResult(int number1, int number2, int expectedResult)
        {
            // Act
            var actualResult = _sut.Execute(number1, number2);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
