using NUnit.Framework;

namespace DotNet.UnitTesting.Demo6.Comparator.UnitTests
{
    [TestFixture]
    public class ComparationTests
    {
        [Test]
        public void LessOrEqual_Arguments1And2_ReturnsTrue()
        {
            var comparation = new Comparation();

            var result = comparation.LessOrEqual(1, 2);

            Assert.IsTrue(result);
        }

        [Test]
        public void LessOrEqual_Arguments1And1_ReturnsTrue()
        {
            var comparation = new Comparation();

            var result = comparation.LessOrEqual(1, 1);

            Assert.IsTrue(result);
        }
    }
}
