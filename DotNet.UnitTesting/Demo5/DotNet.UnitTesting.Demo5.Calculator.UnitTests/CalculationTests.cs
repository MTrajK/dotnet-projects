using System;
using NSubstitute;
using NUnit.Framework;
using DotNet.UnitTesting.Demo5.Calculator;
using DotNet.UnitTesting.Demo5.Calculator.Operations;

namespace DotNet.UnitTesting.Demo5.CalculatorUnitTests
{
    [TestFixture]
    public class CalculationTests
    {
        /// <summary>
        /// Demo 5.2
        /// </summary>
        [Test]
        public void Execute_Arguments0And0_Returns0()
        {
            var operation = Substitute.For<IOperation>();
            var calculation = new Calculation(operation);

            var result = calculation.Execute(0, 0);

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Demo 5.3
        /// </summary>
        [Test]
        public void Execute_Arguments1And2_Returns3()
        {
            var operation = Substitute.For<IOperation>();
            operation
                .Execute(1, 2)
                .Returns(3);
            var calculation = new Calculation(operation);

            var result = calculation.Execute(1, 2);

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// Demo 5.3
        /// </summary>
        [Test]
        public void Execute_ArgumentsAnyInt_Returns3()
        {
            var operation = Substitute.For<IOperation>();
            operation
                .Execute(Arg.Any<int>(), Arg.Any<int>())
                .Returns(3);
            var calculation = new Calculation(operation);

            var result = calculation.Execute(1, 2);

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// Demo 5.3
        /// </summary>
        [Test]
        public void Execute_ArgumentsIntBiggerThan0_Returns1()
        {
            var operation = Substitute.For<IOperation>();
            operation
                .Execute(Arg.Is<int>(x => x > 0), Arg.Is<int>(x => x > 0))
                .Returns(1);
            var calculation = new Calculation(operation);

            var result = calculation.Execute(1, 2);

            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Demo 5.4
        /// </summary>
        [Test]
        public void Execute_ArgumentsNegativeValues_ThrowsArgumentException()
        {
            var operation = Substitute.For<IOperation>();
            operation
                .Execute(-1, -1)
                .Returns(x => { throw new ArgumentException(); });
            var calculation = new Calculation(operation);

            Assert.Throws<ArgumentException>(() => calculation.Execute(-1, -1));
        }

        /// <summary>
        /// Demo 5.4
        /// </summary>
        [Test]
        public void Execute_ArgumentsZeros_ThrowsArgumentException()
        {
            var operation = Substitute.For<IOperation>();
            operation
                .When(x => x.Execute(0, 0))
                .Do(x => { throw new ArgumentException(); });
            var calculation = new Calculation(operation);

            Assert.Throws<ArgumentException>(() => calculation.Execute(0, 0));
        }

        /// <summary>
        /// Demo 5.5
        /// </summary>
        [Test]
        public void Execute_Arguments1And2_OperationMethodCalledOnceWithArguments1And2()
        {
            var operation = Substitute.For<IOperation>();
            var calculation = new Calculation(operation);

            calculation.Execute(1, 2);

            operation.Received(1).Execute(1, 2);
        }

        /// <summary>
        /// Demo 5.6
        /// </summary>
        [Test]
        public void Execute_Arguments1And2_CalledInOrder()
        {
            var operation = Substitute.For<IOperation>();
            var calculation = new Calculation(operation);

            calculation.Execute(1, 2);

            Received.InOrder(() => { 
                operation.Execute(1, 2); 
            });
        }
    }
}
