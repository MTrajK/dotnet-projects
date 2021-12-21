using System;

namespace DotNet.ProgrammingPrinciples.ISP.Old
{
    public class GeometricRectangle : IShape
    {
        private double _height;
        private double _width;

        public GeometricRectangle(double height, double width)
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
            throw new NotImplementedException("No need from drawing GeometricRectangle");
        }
    }
}
