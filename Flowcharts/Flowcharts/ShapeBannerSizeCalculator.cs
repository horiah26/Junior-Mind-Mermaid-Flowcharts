﻿using System.Linq;

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
                length = 35;
            }
            else if (maxLineLength > 1 && maxLineLength <= 3)
            {
                length = sizeOfText * 9 + 10;
            }
            else if (maxLineLength > 3 && maxLineLength <= 7)
            {
                length = sizeOfText * 8;
            }
            else
            {
                length = sizeOfText * 7.2;
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
