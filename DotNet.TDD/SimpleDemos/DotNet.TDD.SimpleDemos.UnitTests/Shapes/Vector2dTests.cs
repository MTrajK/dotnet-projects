using DotNet.TDD.SimpleDemos.Shapes;
using FluentAssertions;
using NUnit.Framework;

namespace DotNet.TDD.SimpleDemos.UnitTests.Shapes
{
    public class Vector2dTests
    {
        [Test]
        public void Add_X4Y2_X5Y4()
        {
            // Arrange
            var vector = new Vector2d(1, 2);
            var addVector = new Vector2d(4, 2);

            // Act
            var result = vector.Add(addVector);

            // Assert
            result.Should().BeEquivalentTo(new Vector2d(5, 4));
        }
    }
}
