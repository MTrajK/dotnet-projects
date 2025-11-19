namespace DotNet.MeaningfulUnitTests.Date.Traditional.Date
{
    public class Year
    {
        private readonly int year;

        public Year(int year)
        {
            this.year = year;
        }

        public bool IsLeapYear()
        {
            return IsYearDivisibleBy(4) &&
                (!IsYearDivisibleBy(100) || IsYearDivisibleBy(400));
        }

        private bool IsYearDivisibleBy(int divisor)
        {
            var remainder = this.year % divisor;
            return remainder == 0;
        }
    }
}
