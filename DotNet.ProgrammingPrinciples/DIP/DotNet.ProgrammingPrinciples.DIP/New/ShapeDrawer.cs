namespace DotNet.ProgrammingPrinciples.DIP.New
{
    public class ShapeDrawer
    {
        private IShape _shape;
        
        public ShapeDrawer(IShape shape) 
        {
            _shape = shape;
        }

        public void Draw()
        {
            _shape.Draw();
        }
    }
}
