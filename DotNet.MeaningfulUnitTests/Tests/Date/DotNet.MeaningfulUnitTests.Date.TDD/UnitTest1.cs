namespace DotNet.MeaningfulUnitTests.Date.TDD
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
            "a".Should().Be("b");
        }
    }
}
