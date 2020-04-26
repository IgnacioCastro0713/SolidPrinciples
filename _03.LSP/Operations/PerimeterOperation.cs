using System.Collections.Generic;
using _03.LSP.Geometric;

namespace _03.LSP.Operations
{
    public class PerimeterOperation
    {
        public static double Sum(IEnumerable<IGeometricShape> shapes)
        {
            double perimeter = 0;
            foreach (var shape in shapes)
                perimeter += shape.Perimeter();
            return perimeter;
        }
    }
}