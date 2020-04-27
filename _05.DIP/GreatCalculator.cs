using System.Collections.Generic;
using _05.DIP.Geometric;
using _05.DIP.Operations;

namespace _05.DIP
{
    public class GreatCalculator
    {
        public double TotalAreas { get; private set; }
        public double TotalPerimeters { get; private set; }

        public void Calculate(IEnumerable<IGeometricShape> figures)
        {
            var geometricShapes = figures as IGeometricShape[];

            TotalAreas = AreaOperation.Sum(geometricShapes);
            TotalPerimeters = PerimeterOperation.Sum(geometricShapes);
        }
    }
}