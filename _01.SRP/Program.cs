using System;
using _00.INIT.Shapes;
using _01.SRP.Operations;

namespace _01.SRP
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

            var sumAreas = AreaOperation.Sum(rectangles);
            var sumPerimeters = PerimeterOperation.Sum(rectangles);

            Console.WriteLine($"Total Area: {sumAreas}");
            Console.WriteLine($"Total Perimeters: {sumPerimeters}");

            Console.ReadKey();
        }
    }
}