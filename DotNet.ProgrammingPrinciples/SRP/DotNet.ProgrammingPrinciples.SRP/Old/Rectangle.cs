// Using Some.Gui

namespace DotNet.ProgrammingPrinciples.SRP.Old
{
    public class Rectangle
    {
        private double _height;
        private double _width;

        public Rectangle(double height, double width)
        {
            _height = height;
            _width = width;
        }

        public double GetArea()
        {
            return _height * _width;
        }

        public void Draw()
        {
            // Draws a rectangle
            // Uses Some.GUI
        }
    }
}
