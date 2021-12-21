using System.Linq;
using NUnit.Framework;
using DotNet.CleanCode.Functions.New;

namespace DotNet.CleanCode.Functions.UnitTests.New
{
    [TestFixture]
    public class PrimeGeneratorTests
    {
        [Test]
        public void GeneratePrimes_MaximumValue0_ReturnsEmptyArray()
        {
            int[] nullArray = PrimeGenerator.GeneratePrimes(0);

            Assert.AreEqual(0, nullArray.Length);
        }

        [Test]
        public void GeneratePrimes_MaximumValue2_ReturnsArrayWithOneElement2()
        {
            int[] nullArray = PrimeGenerator.GeneratePrimes(2);

            Assert.IsTrue(nullArray.SequenceEqual(new int[] { 2 }));
        }

        [Test]
        public void GeneratePrimes_MaximumValue3_ReturnsArrayWithTwoElements2And3()
        {
            int[] nullArray = PrimeGenerator.GeneratePrimes(3);

            Assert.IsTrue(nullArray.SequenceEqual(new int[] { 2, 3 }));
        }

        [Test]
        public void GeneratePrimes_MaximumValue100_ReturnsArrayWith25Elements()
        {
            int[] nullArray = PrimeGenerator.GeneratePrimes(100);

            Assert.AreEqual(25, nullArray.Length);
        }
    }
}
