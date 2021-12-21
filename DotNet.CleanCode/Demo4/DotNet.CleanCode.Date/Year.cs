namespace DotNet.CleanCode.Date
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
 * Step 2 - first test fails
using System;

namespace DotNet.CleanCode.Date
{
    public class Year
    {
        public Year(int year)
        {
        }

        public bool IsLeapYear()
        {
            throw new NotImplementedException();
        }
    }
}
*/

/*
 * Step 3 - first & second test pass, third fails
namespace DotNet.CleanCode.Date
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
            return (_year % 4) == 0;
        }
    }
}
*/

/*
 * Step 4 - first, second, third test pass, fourth fails
namespace DotNet.CleanCode.Date
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
            var divisibleBy4 = (_year % 4) == 0;
            if (divisibleBy4)
            {
                return (_year % 100) != 0;
            } else
            {
                return false;
            }
        }
    }
}
*/

/*
 * Step 5 - all tests pass
namespace DotNet.CleanCode.Date
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
            var divisibleBy4 = (_year % 4) == 0;
            if (divisibleBy4)
            {
                var divisibleBy100 = (_year % 100) == 0;
                if (divisibleBy100)
                {
                    return (_year % 400) == 0;
                } else
                {
                    return true;
                }
            } else
            {
                return false;
            }
        }
    }
}
*/

/*
 * Step 6 - First refactoring
namespace DotNet.CleanCode.Date
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
                } else
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
