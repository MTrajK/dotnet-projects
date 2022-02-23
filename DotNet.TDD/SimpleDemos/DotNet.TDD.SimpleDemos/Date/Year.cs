// Step 11 - Correct refactor, green tests, boolean logic
namespace DotNet.TDD.SimpleDemos.Date
{
    public class Year
    {
        private int _year;

        public Year(int year)
        {
            _year = year;
        }

        public bool IsLeapYear()
        {
            return IsYearDivisibleBy(4) &&
                (!IsYearDivisibleBy(100) || IsYearDivisibleBy(400));
        }

        private bool IsYearDivisibleBy(int divisor)
        {
            var remainder = _year % divisor;
            return remainder == 0;
        }
    }
}

/*
// Step 10 - Wrong refactor, two tests fails
namespace DotNet.TDD.SimpleDemos.Date
{
    public class Year
    {
        private int _year;

        public Year(int year)
        {
            _year = year;
        }

        public bool IsLeapYear()
        {
            return IsYearDivisibleBy(4) &&
                (IsYearDivisibleBy(100) || IsYearDivisibleBy(400));
        }

        private bool IsYearDivisibleBy(int divisor)
        {
            var remainder = _year % divisor;
            return remainder == 0;
        }
    }
}
*/

/*
// Step 9 - Refactor, new function
namespace DotNet.TDD.SimpleDemos.Date
{
    public class Year
    {
        private int _year;

        public Year(int year)
        {
            _year = year;
        }

        public bool IsLeapYear()
        {
            if (IsYearDivisibleBy(4))
            {
                if (IsYearDivisibleBy(100))
                {
                    return IsYearDivisibleBy(400);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsYearDivisibleBy(int divisor)
        {
            var remainder = _year % divisor;
            return remainder == 0;
        }
    }
}
*/

/*
// Step 8 - Fixes the fourth test
namespace DotNet.TDD.SimpleDemos.Date
{
    public class Year
    {
        private int _year;

        public Year(int year)
        {
            _year = year;
        }

        public bool IsLeapYear()
        {
            if (_year % 4 == 0)
            {
                if (_year % 100 == 0)
                {
                    return _year % 400 == 0;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
*/

/*
// Step 6 - Fixes the third test
namespace DotNet.TDD.SimpleDemos.Date
{
    public class Year
    {
        private int _year;

        public Year(int year)
        {
            _year = year;
        }

        public bool IsLeapYear()
        {
            if (_year % 4 == 0)
            {
                return _year % 100 != 0;
            }
            else
            {
                return false;
            }
        }
    }
}
*/

/*
// Step 4 - Passes first 2 tests
namespace DotNet.TDD.SimpleDemos.Date
{
    public class Year
    {
        private int _year;

        public Year(int year)
        {
            _year = year;
        }

        public bool IsLeapYear()
        {
            return _year % 4 == 0;
        }
   }
}
*/

/*
// Step 2 - Passes test IsLeapYear_LeapYear_ReturnsTrue
namespace DotNet.TDD.SimpleDemos.Date
{
    public class Year
    {
        public Year(int year)
        {

        }

        public bool IsLeapYear()
        {
            return true;
        }
    }
}
*/