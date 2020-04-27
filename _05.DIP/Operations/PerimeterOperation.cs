using System.Collections.Generic;
using System.Linq;
using _05.DIP.Geometric.Segregations;

namespace _05.DIP.Operations
{
    public class PerimeterOperation
    {
        public static double Sum(IEnumerable<IHasPerimeter> shapes)
        {
            return shapes.Sum(shape => shape.Perimeter());
        }
    }
}