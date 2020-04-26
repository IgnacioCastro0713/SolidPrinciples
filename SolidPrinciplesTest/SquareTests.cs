using _03.LSP.Shapes;
using NUnit.Framework;

namespace SolidPrinciplesTest
{
    [TestFixture]
    public class SquareTests
    {
        [Test]
        public void SquareAreaTest()
        {
            Square square = new Square {SideLength = 6};

            const double expected = 36;
            var actual = square.Area();

            Assert.AreEqual(expected, actual);
        }
    }
}