using System;
using _00.INIT.Shapes;

namespace _00.INIT
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rectangles = new[]
            {
                new Rectangle {Width = 10, Height = 5},
                new Rectangle {Width = 4, Height = 6},
                new Rectangle {Width = 5, Height = 1},
                new Rectangle {Width = 8, Height = 9}
            };

            var sumAreas = Rectangle.SumAreas(rectangles);
            var sumPerimeters = Rectangle.SumPerimeters(rectangles);

            Console.WriteLine($"Total Area: {sumAreas}");
            Console.WriteLine($"Total Perimeters: {sumPerimeters}");

            Console.ReadKey();
        }
    }
}