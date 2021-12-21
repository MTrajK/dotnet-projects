namespace DotNet.ProgrammingPrinciples.LSP.Old
{
    public class ShapeDrawer
    {
        public static void DrawAllShapes(IShape[] shapes)
        {
            foreach (IShape shape in shapes)
            {
                if (shape is Square)
                    (shape as Square).Draw();
                else if (shape is Rectangle)
                    (shape as Rectangle).Draw();
            }
        }
    }
}
