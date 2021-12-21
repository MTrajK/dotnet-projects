namespace DotNet.ProgrammingPrinciples.ISP.New
{
    public class GeometricRectangle : IGeometricShape
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
    }
}
