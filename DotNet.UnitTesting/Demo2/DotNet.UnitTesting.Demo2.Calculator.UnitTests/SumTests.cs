using NUnit.Framework;
using DotNet.UnitTesting.Demo2.Calculator;

namespace DotNet.UnitTesting.Demo2.CalculatorUnitTests
{
    /// <summary>
    /// Demo 2.2
    /// </summary>
    [TestFixture]
    public class SumTests
    {
        /// <summary>
        /// Demo 2.2
        /// </summary>
        [Test]
        public void TestAttribute_EmptyTest_Pass()
        {
        }

        /// <summary>
        /// Demo 2.3
        /// </summary>
        [Test]
        public void Assert_TrueCondition_Pass()
        {
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Demo 2.3
        /// </summary>
        [Test]
        public void Assert_FalseCondition_Fail()
        {
            Assert.AreEqual(2, 3);
        }

        /// <summary>
        /// Demo 2.4 & 2.5
        /// </summary>
        [Test]
        public void Add_Arguments1And2_Returns3()
        {
            var sum = new Sum();

            var result = sum.Add(1, 2);

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// Demo 2.6
        /// </summary>
        [TestCase(1, 2, 3)]
        [TestCase(5, 3, 8)]
        [TestCase(-2, 4, 2)]
        public void Add_DifferentArgumentsCombinations_ReturnsExpectedResult(int a, int b, int expectedResult)
        {
            var sum = new Sum();

            var actualResult = sum.Add(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Demo 2.7
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        /// <summary>
        /// Demo 2.7
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }

        /// <summary>
        /// Demo 2.7
        /// </summary>
        [SetUp]
        public void SetUp()
        {

        }

        /// <summary>
        /// Demo 2.7
        /// </summary>
        [TearDown]
        public void TearDown()
        {

        }

        /// <summary>
        /// Demo 2.7
        /// </summary>
        [Test]
        public void Add_Arguments5And5_Returns10()
        {
            var sum = FactoryMethod();

            var result = sum.Add(5, 5);

            Assert.AreEqual(10, result);
        }

        /// <summary>
        /// Demo 2.7
        /// </summary>
        private Sum FactoryMethod()
        {
            return new Sum();
        }

        /// <summary>
        /// Demo 2.8
        /// </summary>
        [Test]
        [Ignore("Returns 10 instead 9")]
        public void Add_Arguments5And5_Returns9()
        {
            var sum = new Sum();

            var result = sum.Add(5, 5);

            Assert.AreEqual(9, result);
        }

        /// <summary>
        /// Demo 2.8
        /// </summary>
        [Test]
        [Category("LongRunning")]
        public void Add_Arguments3And3_Returns6()
        {
            var sum = new Sum();

            var result = sum.Add(3, 3);

            Assert.AreEqual(6, result);
        }
    }
}
