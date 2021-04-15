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
            var lines = TextOperations.SplitText(text);
            var numberOfLines = lines.Length;

            height = 40 + (numberOfLines - 1) * 17;
            length = TextOperations.CalculateLength(lines);

            return (height, length);
        }
    }
}
