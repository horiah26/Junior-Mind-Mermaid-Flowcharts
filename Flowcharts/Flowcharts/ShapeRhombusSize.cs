using System.Linq;

namespace Flowcharts
{
    class ShapeRhombusSize
    {
        readonly string[] lines;

        public ShapeRhombusSize(string[] lines)
        {
            this.lines = lines;
        }

        public double GetSize()
        {
            var sizeOfText = new TextSizeCalculator(lines).Calculate();
            var maxLineLength = lines.Max(x => x.Length);

            if (maxLineLength == 1)
            {
                return 40;
            }
            else if (maxLineLength > 1 && maxLineLength <= 3)
            {
                return sizeOfText * 11 + 5;
            }
            else if (maxLineLength > 3 && maxLineLength <= 6)
            {
                return sizeOfText * 8.5 + 5;
            }

            return sizeOfText * 7.5;
        }
    }
}
