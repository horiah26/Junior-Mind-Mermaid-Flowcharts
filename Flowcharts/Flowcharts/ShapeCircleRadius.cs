using System.Linq;


namespace Flowcharts
{
    class ShapeCircleRadius
    {
        readonly string text;
        public ShapeCircleRadius(string text)
        {
            this.text = text;           
        }

        public double GetRadius()
        {
            var lines = new SplitText(text).GetLines();
            var numberOfLines = lines.Length;

            var sizeOfText = new TextSizeCalculator(lines).Calculate();
            var maxLineLength = lines.Max(x => x.Length);

            if (maxLineLength == 1)
            {
                return 20;
            }
            else if (maxLineLength > 1 && maxLineLength <= 3)
            {
                return sizeOfText * 5.5;
            }
            else if (maxLineLength > 3 && maxLineLength <= 6)
            {
                return sizeOfText * 4;
            }

            return sizeOfText * 3.4;
        }
    }
}