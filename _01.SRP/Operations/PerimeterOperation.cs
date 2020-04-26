using System.Collections.Generic;
using _00.INIT.Shapes;

namespace _01.SRP.Operations
{
    public class PerimeterOperation
    {
        public static double Sum(IEnumerable<Rectangle> rectangles)
        {
            double perimeter = 0;
            foreach (var rectangle in rectangles)
                perimeter += (2 * rectangle.Height) + (2 * rectangle.Width);
            return perimeter;
        }
    }
}