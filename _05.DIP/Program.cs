using System;

namespace _05.DIP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var calculator = new GreatCalculator();
            calculator.Calculate();

            Console.WriteLine($"Total Area: {calculator.TotalAreas}");
            Console.WriteLine($"Total Perimeter:{calculator.TotalPerimeters}");
            Console.ReadKey();
        }
    }
}