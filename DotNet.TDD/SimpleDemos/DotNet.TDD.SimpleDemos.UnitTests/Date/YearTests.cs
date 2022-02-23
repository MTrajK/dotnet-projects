using DotNet.TDD.SimpleDemos.Date;
using NUnit.Framework;

namespace DotNet.TDD.SimpleDemos.UnitTests.Date
{
    /// <summary>
    /// To be a leap year, the year number must be divisible by four – except for end-of-century years, which must be divisible by 400.
    /// </summary>
    public class YearTests
    {
        // Step 1 - Don't compile
        [Test]
        public void IsLeapYear_LeapYear_ReturnsTrue()
        {
            // Arrange
            var year = 2004;
            var sut = new Year(year);

            // Act
            var result = sut.IsLeapYear();

            // Assert
            Assert.IsTrue(result);
        }

        // Step 3 - Fails
        [Test]
        public void IsLeapYear_NotLeapYear_ReturnsFalse()
        {
            // Arrange
            var year = 1999;
            var sut = new Year(year);

            // Act
            var result = sut.IsLeapYear();

            // Assert
            Assert.IsFalse(result);
        }

        // Step 5 - Fails
        [Test]
        public void IsLeapYear_DivisibleBy100_ReturnsFalse()
        {
            // Arrange
            var year = 1900;
            var sut = new Year(year);

            // Act
            var result = sut.IsLeapYear();

            // Assert
            Assert.IsFalse(result);
        }

        // Step 7 - Fails
        [Test]
        public void IsLeapYear_DivisibleBy400_ReturnsTrue()
        {
            // Arrange
            var year = 2000;
            var sut = new Year(year);

            // Act
            var result = sut.IsLeapYear();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
