using System.Collections.Generic;
using _04.ISP.Geometric.Segregations;

namespace _04.ISP.Operations
{
    public class PerimeterOperation
    {
        public static double Sum(IEnumerable<IHasPerimeter> shapes)
        {
            double perimeter = 0;
            foreach (var shape in shapes)
                perimeter += shape.Perimeter();
            return perimeter;
        }
    }
}