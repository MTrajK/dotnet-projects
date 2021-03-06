namespace DotNet.TDD.SimpleDemos.Shapes
{
    public class Circle
    {
        public Vector2d Center { get; private set; }

        public Circle(Vector2d center)
        {
            Center = center;
        }

        public void Move(Vector2d direction)
        {
            Center = Center.Add(direction);
        }
    }
}

/*
// Step 6 - new structure, fix X
namespace DotNet.TDD.SimpleDemos.Shapes
{
    public class Circle
    {
        public int X;
        public int Y;

        public Circle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int horizontalStep, int verticalStep)
        {
            X = 3;
            Y += verticalStep;
        }
    }
}
*/

/*
// Step 4 - fixing 3rd test
namespace DotNet.TDD.SimpleDemos.Shapes
{
    public class Circle
    {
        public int X;
        public int Y;

        public Circle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int verticalStep)
        {
            Y += verticalStep;
        }
    }
}
*/

/*
// Step 2 - fixing test
namespace DotNet.TDD.SimpleDemos.Shapes
{
    public class Circle
    {
        public int X;
        public int Y;

        public Circle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int verticalStep)
        {
            Y = 4;
        }
    }
}
*/
