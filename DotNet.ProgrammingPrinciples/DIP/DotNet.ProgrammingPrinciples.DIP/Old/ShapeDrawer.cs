namespace DotNet.ProgrammingPrinciples.DIP.Old
{
    public class ShapeDrawer
    {
        private Circle _circle;

        public ShapeDrawer()
        {
            _circle = new Circle();
        }

        public void Draw()
        {
            _circle.Draw();
        }
    }
}
