using System.Linq;

namespace Flowcharts
{
    class ShapeLengthCalculator
    {
        public string[] lines;
        public ShapeLengthCalculator(string[] lines)
        {
            this.lines = lines;
        }

        public double GetLength()
        {
            var sizeOfText = new TextSizeCalculator(lines).Calculate();
            var maxLineLength = lines.Max(x => x.Length);

            if (maxLineLength == 1)
            {
                return 30;
            }
            else if (maxLineLength > 1 && maxLineLength <= 3)
            {
                return sizeOfText * 8 + 5;
            }
            else if (maxLineLength > 3 && maxLineLength <= 6)
            {
                return sizeOfText * 7 + 5;
            }
            return sizeOfText * 6.5;        
        }
    }
}
