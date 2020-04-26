using System;
using _02.OCP.Geometric;
using _02.OCP.Operations;
using _02.OCP.Shapes;

namespace _02.OCP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var figures = new IGeometricShape[]
            {
                new Rectangle {Width = 10, Height = 5},
                new EquilateralTriangle {SideLength = 5},
                new Rectangle {Width = 4, Height = 6},
                new Rectangle {Width = 8, Height = 9},
                new EquilateralTriangle {SideLength = 5}
            };

            var sumAreas = AreaOperation.Sum(figures);
            var sumPerimeters = PerimetersOperation.Sum(figures);

            Console.WriteLine($"Total Area: {sumAreas}");
            Console.WriteLine($"Total Perimeters: {sumPerimeters}");

            Console.ReadKey();
        }
    }
}