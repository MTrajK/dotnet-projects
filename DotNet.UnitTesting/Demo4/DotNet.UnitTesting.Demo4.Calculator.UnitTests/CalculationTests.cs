using NUnit.Framework;
using DotNet.UnitTesting.Demo4.Calculator;
using DotNet.UnitTesting.Demo4.CalculatorUnitTests.Fakes;

namespace DotNet.UnitTesting.Demo4.CalculatorUnitTests
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        public void Execute_Arguments1And2_Returns3()
        {
            var sumStub = new SumStub();
            var calculation = new Calculation(sumStub);

            var result = calculation.Execute(1, 2);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Execute_Arguments1And2_CalledOnce()
        {
            var sumMock = new SumMock();
            var calculation = new Calculation(sumMock);

            calculation.Execute(1, 2);

            Assert.AreEqual(1, sumMock.CallsCount);
        }
    }
}
