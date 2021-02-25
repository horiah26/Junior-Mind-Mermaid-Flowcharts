using System.Linq;


namespace Flowcharts
{
    class ShapeCircleRadiusCalculator
    {
        readonly string text;
        public ShapeCircleRadiusCalculator(string text)
        {
            this.text = text;
           
        }

        public double Calculate()
        {
            (string[] lines, int numberOfLines) = new TextSplitter(text).Split();
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