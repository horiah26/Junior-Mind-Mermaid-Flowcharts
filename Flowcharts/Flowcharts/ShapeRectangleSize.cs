namespace Flowcharts
{
    class ShapeRectangleSize
    {
        readonly string text;

        public ShapeRectangleSize(string text)
        {
            this.text = text;
        }

        public double height;
        public double length;

        public (double height, double length) GetSize()
        {
            var lines = new SplitText(text).GetLines();
            var numberOfLines = lines.Length;

            height = 40 + (numberOfLines - 1) * 17;
            length = new ShapelengthCalculator(lines).GetLength();

            return (height, length);
        }
    }
}
