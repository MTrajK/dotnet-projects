namespace DotNet.ProgrammingPrinciples.LSP.New
{
    public class ShapeDrawer
    {
        public static void DrawAllShapes(IShape[] shapes)
        {
            foreach (IShape shape in shapes)
                shape.Draw();
        }
    }
}
