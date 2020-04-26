using _03.LSP.Shapes;
using NUnit.Framework;

namespace SolidPrinciplesTest
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void RectangleAreaTest()
        {
            Rectangle rectangle = new Rectangle {Width = 3, Height = 6};

            const double expected = 18;
            var actual = rectangle.Area();

            Assert.AreEqual(expected, actual);
        }
    }
}