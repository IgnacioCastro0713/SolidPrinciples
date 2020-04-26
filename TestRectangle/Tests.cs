using _03.LSP.Shapes;
using NUnit.Framework;

namespace TestRectangle
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Rectangle rectangle = new Square();
            rectangle.Width = 3;
            rectangle.Height = 6;

            const double expected = 18;
            var actual = rectangle.Area();

            Assert.AreEqual(expected, actual);        }
    }
}