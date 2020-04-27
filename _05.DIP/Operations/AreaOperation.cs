using System.Collections.Generic;
using System.Linq;
using _05.DIP.Geometric.Segregations;

namespace _05.DIP.Operations
{
    public class AreaOperation
    {
        public static double Sum(IEnumerable<IHasArea> shapes)
        {
            return shapes.Sum(shape => shape.Area());
        }
    }
}