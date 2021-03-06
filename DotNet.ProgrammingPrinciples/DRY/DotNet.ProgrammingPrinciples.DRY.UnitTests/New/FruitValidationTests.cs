using NUnit.Framework;
using DotNet.ProgrammingPrinciples.DRY.New;

namespace DotNet.ProgrammingPrinciples.DRY.UnitTests.New
{
    [TestFixture]
    public class FruitValidationTests
    {
        [Test]
        public void IsValidFruit_Banana_ReturnsTrue()
        {
            var isValidFruit = FruitValidation.IsValidFruit("Banana");

            Assert.IsTrue(isValidFruit);
        }

        [Test]
        public void IsValidFruit_BananaAlternatingCaps_ReturnsTrue()
        {
            var isValidFruit = FruitValidation.IsValidFruit("baNaNA");

            Assert.IsTrue(isValidFruit);
        }

        [Test]
        public void IsValidFruit_Apple_ReturnsTrue()
        {
            var isValidFruit = FruitValidation.IsValidFruit("Apple");

            Assert.IsTrue(isValidFruit);
        }

        [Test]
        public void IsValidFruit_Onion_ReturnsFalse()
        {
            var isValidFruit = FruitValidation.IsValidFruit("Onion");

            Assert.IsFalse(isValidFruit);
        }
    }
}