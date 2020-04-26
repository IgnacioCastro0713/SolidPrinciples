namespace _03.LSP.Shapes
{
    public class Square : Rectangle
    {
        private double _height;
        private double _width;

        public override double Height
        {
            get => _height;
            set
            {
                _height = value;
                _width = value;
            }
        }

        public override double Width
        {
            get => _width;
            set
            {
                _width = value;
                _height = value;
            }
        }
    }
}