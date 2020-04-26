using System.Collections.Generic;
using _02.OCP.Geometric;

namespace _02.OCP.Operations
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