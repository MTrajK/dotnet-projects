using NUnit.Framework;

namespace DotNet.CleanCode.Date.UnitTests
{
    [TestFixture]
    public class YearTests
    {
        [Test]
        public void IsLeapYear_Year1992_ReturnsTrue()
        {
            var year = new Year(1992);

            var isLeapYear = year.IsLeapYear();

            Assert.IsTrue(isLeapYear);
        }

        [Test]
        public void IsLeapYear_Year2021_ReturnsFalse()
        {
            var year = new Year(2021);

            var isLeapYear = year.IsLeapYear();

            Assert.IsFalse(isLeapYear);
        }

        [Test]
        public void IsLeapYear_Year1900_ReturnsFalse()
        {
            var year = new Year(1900);

            var isLeapYear = year.IsLeapYear();

            Assert.IsFalse(isLeapYear);
        }

        [Test]
        public void IsLeapYear_Year2000_ReturnsTrue()
        {
            var year = new Year(2000);

            var isLeapYear = year.IsLeapYear();

            Assert.IsTrue(isLeapYear);
        }
    }
}
