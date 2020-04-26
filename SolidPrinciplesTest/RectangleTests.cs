using System;
using _03.LSP.Shapes;
using NUnit.Framework;

namespace SolidPrinciplesTest
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void RecTangleAreaTest()
        {
            Rectangle rectangle = new Square {Width = 3, Height = 6};

            const double expected = 18;
            var actual = rectangle.Area();

            Assert.AreEqual(expected, actual);
        }
    }
}