using System;
using _05.DIP.Geometric;
using _05.DIP.Shapes;

namespace _05.DIP
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

            var calculator = new GreatCalculator();
            calculator.Calculate(figures);

            Console.WriteLine($"Total Areas: {calculator.TotalAreas}");
            Console.WriteLine($"Total Perimeters: {calculator.TotalPerimeters}");

            Console.ReadKey();
        }
    }
}