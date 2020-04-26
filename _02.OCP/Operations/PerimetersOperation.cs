using System.Collections.Generic;
using _02.OCP.Shapes;

namespace _02.OCP.Operations
{
    public class PerimetersOperation
    {
        public static double Sum(IEnumerable<object> shapes)
        {
            double perimeter = 0;
            foreach (var shape in shapes)
            {
                switch (shape)
                {
                    case Rectangle rectangle:
                        perimeter += 2 * rectangle.Height + 2 * rectangle.Width;
                        break;
                    case EquilateralTriangle triangle:
                        perimeter += triangle.SideLength * 3;
                        break;
                }
            }

            return perimeter;
        }
    }
}