using _05.DIP.Geometric;
using _05.DIP.Operations;
using _05.DIP.Shapes;

namespace _05.DIP
{
    public class GreatCalculator
    {
        public double TotalAreas { get; private set; }
        public double TotalPerimeters { get; private set; }

        public void Calculate()
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

            var areaOperations = new AreaOperation();
            var perimeterOperations = new PerimeterOperation();

            TotalAreas = areaOperations.Sum(figures);
            TotalPerimeters = perimeterOperations.Sum(figures);
        }
    }
}