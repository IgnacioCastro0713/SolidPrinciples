using System.Collections.Generic;
using _05.DIP.Geometric.Segregations;

namespace _05.DIP.Operations
{
    public class PerimeterOperation
    {
        public double Sum(IEnumerable<IHasPerimeter> shapes)
        {
            double perimeter = 0;
            foreach (var shape in shapes)
                perimeter += shape.Perimeter();
            return perimeter;
        }
    }
}