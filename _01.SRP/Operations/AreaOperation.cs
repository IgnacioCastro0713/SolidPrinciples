using System.Collections.Generic;
using _00.INIT.Shapes;

namespace _01.SRP.Operations
{
    public class AreaOperation
    {
        public static double Sum(IEnumerable<Rectangle> rectangles)
        {
            double area = 0;
            foreach (var rectangle in rectangles)
                area += rectangle.Height * rectangle.Width;
            return area;
        }
    }
}