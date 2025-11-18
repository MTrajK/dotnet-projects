namespace DotNet.MeaningfulUnitTests.Date.Traditional
{
    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            "a".Should().Be("a");
        }
    }
}
