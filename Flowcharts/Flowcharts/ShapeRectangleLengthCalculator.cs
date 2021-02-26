using System.Linq;

namespace Flowcharts
{
    class ShapelengthCalculator
    {
        public string[] lines;
        public ShapelengthCalculator(string[] lines)
        {
            this.lines = lines;
        }

        public double Calculate()
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

            return sizeOfText * 6.5;        
        }
    }
}
