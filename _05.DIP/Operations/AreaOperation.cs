using System.Collections.Generic;
using _05.DIP.Geometric.Segregations;

namespace _05.DIP.Operations
{
    public class AreaOperation
    {
        public double Sum(IEnumerable<IHasArea> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
                area += shape.Area();
            return area;
        }
    }
}