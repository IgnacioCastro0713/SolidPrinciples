using System.Collections.Generic;
using _03.LSP.Geometric;

namespace _03.LSP.Operations
{
    public class AreaOperation
    {
        public static double Sum(IEnumerable<IGeometricShape> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
                area += shape.Area();
            return area;
        }
    }
}