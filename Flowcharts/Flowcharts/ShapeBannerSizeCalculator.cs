using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ShapeBannerSizeCalculator
    {
        readonly string[] lines;

        public ShapeBannerSizeCalculator(string[] lines)
        {
            this.lines = lines;
        }

        public (double height, double length) Calculate()
        {
            var sizeOfText = new TextSizeCalculator(lines).Calculate();
            var maxLineLength = lines.Max(x => x.Length);
            var numberOfLines = lines.Length;

            double height;
            double length;

            if (maxLineLength == 1)
            {
                length = 40;
            }
            else if (maxLineLength > 1 && maxLineLength <= 3)
            {
                length = sizeOfText * 12 + 5;
            }
            else if (maxLineLength > 3 && maxLineLength <= 6)
            {
                length = sizeOfText * 12;
            }
            else
            {
                length = sizeOfText * 9;
            }

            if(numberOfLines == 1)
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
