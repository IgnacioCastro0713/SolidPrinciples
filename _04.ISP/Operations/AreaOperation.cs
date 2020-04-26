using System.Collections.Generic;
using _04.ISP.Geometric.Segregations;

namespace _04.ISP.Operations
{
    public class AreaOperation
    {
        public static double Sum(IEnumerable<IHasArea> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
                area += shape.Area();
            return area;
        }
    }
}