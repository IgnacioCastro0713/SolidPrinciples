using System;
using System.Collections.Generic;
using _02.OCP.Shapes;

namespace _02.OCP.Operations
{
    public class AreaOperation
    {
        public static double Sum(IEnumerable<object> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                switch (shape)
                {
                    case Rectangle rectangle:
                        area += rectangle.Height * rectangle.Width;
                        break;
                    case EquilateralTriangle triangle:
                        area += Math.Sqrt(3) * Math.Pow(triangle.SideLength, 2) / 4;
                        break;
                }
            }

            return area;
        }
    }
}