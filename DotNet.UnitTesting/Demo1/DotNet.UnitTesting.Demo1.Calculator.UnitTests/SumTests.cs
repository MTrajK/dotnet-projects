using System;
using DotNet.UnitTesting.Demo1.Calculator;

namespace DotNet.UnitTesting.Demo1.CalculatorUnitTests
{
    public static class SumTests
    {
        public static void Add_Arguments1And2_Returns3()
        {
            var sum = new Sum();

            var result = sum.Add(1, 2);

            if (result == 3)
                Console.WriteLine("Add_Arguments1And2_Returns3 passed");
            else
                Console.WriteLine("Add_Arguments1And2_Returns3 failed - expected 3, actual " + result);
        }

        public static void Add_Arguments5And3_Returns8()
        {
            var sum = new Sum();

            var result = sum.Add(5, 3);

            if (result == 8)
                Console.WriteLine("Add_Arguments5And3_Returns8 passed");
            else
                Console.WriteLine("Add_Arguments5And3_Returns8 failed - expected 8, actual " + result);
        }
    }
}
