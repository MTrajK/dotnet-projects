namespace DotNet.MeaningfulUnitTests.Date.Traditional.UnitTests.Date
{
    using DotNet.MeaningfulUnitTests.Date.Traditional.Date;

    using FluentAssertions;

    [TestClass]
    public class YearTests
    {
        [TestMethod]
        public void IsLeapYear_OddYear_ReturnsFalse()
        {
            // Arrange
            var year = 1999;
            var sut = new Year(year);

            // Act
            var result = sut.IsLeapYear();

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsLeapYear_DivisibleBy4ButNotBy100And400_ReturnsTrue()
        {
            // Arrange
            var year = 2004;
            var sut = new Year(year);

            // Act
            var result = sut.IsLeapYear();

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsLeapYear_DivisibleBy100ButNotBy400_ReturnsFalse()
        {
            // Arrange
            var year = 1900;
            var sut = new Year(year);

            // Act
            var result = sut.IsLeapYear();

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsLeapYear_DivisibleBy400AndBy100_ReturnsTrue()
        {
            // Arrange
            var year = 2000;
            var sut = new Year(year);

            // Act
            var result = sut.IsLeapYear();

            // Assert
            result.Should().BeTrue();
        }
    }
}
