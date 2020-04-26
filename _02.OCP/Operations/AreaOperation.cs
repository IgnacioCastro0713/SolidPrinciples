using System.Collections.Generic;
using _02.OCP.Geometric;

namespace _02.OCP.Operations
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