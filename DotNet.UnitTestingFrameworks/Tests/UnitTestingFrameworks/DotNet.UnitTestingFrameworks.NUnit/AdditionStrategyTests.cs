using DotNet.UnitTestingFrameworks.BLL.Strategies;
using NUnit.Framework;

namespace DotNet.UnitTestingFrameworks.NUnit
{
    [TestFixture]
    public class AdditionStrategyTests
    {
        private static AdditionStrategy _sut;

        [OneTimeSetUp]
        public static void ClassInitialize()
        {
            // Method that will be called only once before executing any of the test methods present in this class.
            _sut = new AdditionStrategy();
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            // Method that will be called only once after executing all of the test methods present in this class.
            _sut = null;
        }

        [SetUp]
        public void TestInitialize()
        {
            // Method that will be called before each test method present in the class.
        }

        [TearDown]
        public void TestCleanup()
        {
            // Method that will be called after each test method present in the class.
        }

        [Test]
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

        [TestCase(5, 7, 12)]
        [TestCase(10, 6, 16)]
        [TestCase(1, -10, -9)]
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
