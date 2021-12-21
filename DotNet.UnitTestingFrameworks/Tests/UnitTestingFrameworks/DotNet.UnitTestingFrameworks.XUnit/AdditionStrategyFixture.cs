using System;
using DotNet.UnitTestingFrameworks.BLL.Strategies;

namespace DotNet.UnitTestingFrameworks.XUnit
{
    public class AdditionStrategyFixture : IDisposable
    {
        public AdditionStrategy sut;

        public AdditionStrategyFixture()
        {
            // Method that will be called only once before executing any of the test methods present in this class.
            sut = new AdditionStrategy();
        }

        public void Dispose()
        {
            // Method that will be called only once after executing all of the test methods present in this class.
            sut = null;
        }
    }
}
