using System;

namespace DotNet.ProgrammingPrinciples.LSP.Old
{
    public class Circle : IShape
    {
        public void Draw()
        {
            throw new NotImplementedException("No need from drawing Circle");
        }
    }
}
