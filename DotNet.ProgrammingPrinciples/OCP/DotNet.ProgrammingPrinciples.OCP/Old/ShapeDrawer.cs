namespace DotNet.ProgrammingPrinciples.OCP.Old
{
    public class ShapeDrawer
    {
        public static void DrawAllShapes(ShapeType[] shapeTypes)
        {
            foreach (ShapeType shapeType in shapeTypes)
            {
                switch (shapeType)
                {
                    case ShapeType.SQUARE:
                        Square.DrawSquare();
                        break;
                    case ShapeType.CIRCLE:
                        Circle.DrawCircle();
                        break;
                }
            }
        }
    }
}
