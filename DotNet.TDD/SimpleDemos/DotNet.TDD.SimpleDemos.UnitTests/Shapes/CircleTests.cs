using DotNet.TDD.SimpleDemos.Shapes;
using FluentAssertions;
using NUnit.Framework;

namespace DotNet.TDD.SimpleDemos.UnitTests.Shapes
{
    public class CircleTests
    {
        [Test]
        public void Move_1Up_Y4()
        {
            // Arrange
            var center = new Vector2d(2, 3);
            var up1 = new Vector2d(0, 1);
            var circle = new Circle(center);

            // Act
            circle.Move(up1);

            // Assert
            circle.Center.Should().BeEquivalentTo(new Vector2d(2, 4));
        }

        [Test]
        public void Move_3Up_Y6()
        {
            // Arrange
            var center = new Vector2d(2, 3);
            var up3 = new Vector2d(0, 3);
            var circle = new Circle(center);

            // Act
            circle.Move(up3);

            // Assert
            circle.Center.Should().BeEquivalentTo(new Vector2d(2, 6));
        }

        [Test]
        public void Move_1Left_X3()
        {
            // Arrange
            var center = new Vector2d(2, 3);
            var left1 = new Vector2d(1, 0);
            var circle = new Circle(center);

            // Act
            circle.Move(left1);

            // Assert
            circle.Center.Should().BeEquivalentTo(new Vector2d(3, 3));
        }

        [Test]
        public void Move_4Left_X6()
        {
            // Arrange
            var center = new Vector2d(2, 3);
            var left1 = new Vector2d(4, 0);
            var circle = new Circle(center);

            // Act
            circle.Move(left1);

            // Assert
            circle.Center.Should().BeEquivalentTo(new Vector2d(6, 3));
        }

        [Test]
        public void Move_DiagonalX2Y1_X4Y4()
        {
            // Arrange
            var center = new Vector2d(2, 3);
            var diagonal = new Vector2d(2, 1);
            var circle = new Circle(center);

            // Act
            circle.Move(diagonal);

            // Assert
            circle.Center.Should().BeEquivalentTo(new Vector2d(4, 4));
        }
    }
}

/*
// Step 5 - Changing the move structure, and adding one more test, the old 2 tests are failing 
using DotNet.TDD.SimpleDemos.Shapes;
using NUnit.Framework;

namespace DotNet.TDD.SimpleDemos.UnitTests.Shapes
{
    public class CircleTests
    {
        [Test]
        public void Move_1Up_Moves()
        {
            // Arrange
            var circleX = 2;
            var circleY = 3;
            var circle = new Circle(2, 3);

            // Act
            circle.Move(0, 1);

            // Assert
            Assert.AreEqual(circleX, circle.X);
            Assert.AreEqual(circleY + 1, circle.Y);
        }

        [Test]
        public void Move_3Up_Moves()
        {
            // Arrange
            var circleX = 2;
            var circleY = 3;
            var circle = new Circle(2, 3);

            // Act
            circle.Move(0, 3);

            // Assert
            Assert.AreEqual(circleX, circle.X);
            Assert.AreEqual(circleY + 3, circle.Y);
        }

        [Test]
        public void Move_1Left_Moves()
        {
            // Arrange
            var circleX = 2;
            var circleY = 3;
            var circle = new Circle(2, 3);

            // Act
            circle.Move(1, 0);

            // Assert
            Assert.AreEqual(circleX + 1, circle.X);
            Assert.AreEqual(circleY, circle.Y);
        }
    }
}
*/

// Step 3 - failing 3rd test
/*
using DotNet.TDD.SimpleDemos.Shapes;
using NUnit.Framework;

namespace DotNet.TDD.SimpleDemos.UnitTests.Shapes
{
    public class CircleTests
    {
        [Test]
        public void Move_1Up_Moves()
        {
            // Arrange
            var circleX = 2;
            var circleY = 3;
            var circle = new Circle(2, 3);

            // Act
            circle.Move(1);

            // Assert
            Assert.AreEqual(circleX, circle.X);
            Assert.AreEqual(circleY + 1, circle.Y);
        }

        [Test]
        public void Move_3Up_Moves()
        {
            // Arrange
            var circleX = 2;
            var circleY = 3;
            var circle = new Circle(2, 3);

            // Act
            circle.Move(3);

            // Assert
            Assert.AreEqual(circleX, circle.X);
            Assert.AreEqual(circleY + 3, circle.Y);
        }
    }
}
*/

/*
// Step 1 - failing test
using DotNet.TDD.SimpleDemos.Shapes;
using NUnit.Framework;

namespace DotNet.TDD.SimpleDemos.UnitTests.Shapes
{
    public class CircleTests
    {
        [Test]
        public void Move_1Up_Moves()
        {
            // Arrange
            var circleX = 2;
            var circleY = 3;
            var circle = new Circle(2, 3);

            // Act
            circle.Move(1);

            // Assert
            Assert.AreEqual(circleX, circle.X);
            Assert.AreEqual(circleY + 1, circle.Y);
        }
    }
}
*/