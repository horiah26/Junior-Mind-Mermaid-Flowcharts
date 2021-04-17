using System.Linq;

namespace Flowcharts
{
    class ShapeBannerSize
    {
        readonly string[] lines;

        public ShapeBannerSize(string[] lines)
        {
            this.lines = lines;
        }

        public (double height, double length) GetSize()
        {
            var sizeOfText = TextOperations.CalculateSizeOfText(lines);
            var maxLineLength = lines.Max(x => x.Length);
            var numberOfLines = lines.Length;

            double height;
            double length;

            if (maxLineLength == 1)
            {
                length = 35;
            }
            else if (maxLineLength > 1 && maxLineLength <= 3)
            {
                length = sizeOfText * 9 + 10;
            }
            else
            {
                length = sizeOfText * 8;
            }

            if (numberOfLines == 1)
            {
                height = 35;
            }
            else
            {
                height = 18 * (numberOfLines + 1);
            }

            return (height, length);
        }
    }
}