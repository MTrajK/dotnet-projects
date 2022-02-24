namespace DotNet.TDD.SimpleDemos.Shapes
{
    public class Vector2d
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector2d(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2d Add(Vector2d add)
        {
            return new Vector2d(X + add.X, Y + add.Y);
        }
    }
}
