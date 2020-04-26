using System;
using _04.ISP.Geometric;
using _04.ISP.Operations;
using _04.ISP.Shapes;

namespace _04.ISP
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
                new Square {SideLength = 10},
                new Rectangle {Width = 8, Height = 9},
                new Square {SideLength = 8},
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