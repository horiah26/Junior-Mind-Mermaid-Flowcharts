using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ShapeRectangleLengthCalculator
    {
        public string[] lines;
        public ShapeRectangleLengthCalculator(string[] lines)
        {
            this.lines = lines;
        }

        public int Calculate()
        {
            var sizeOfText = new TextSizeCalculator(lines).Calculate();
            var maxLineLength = lines.Max(x => x.Length);

            if (maxLineLength == 1)
            {
                return 25;
            }
            else if (maxLineLength > 1 && maxLineLength <= 3)
            {
                return sizeOfText * 8 + 3;
            }
            else if (maxLineLength > 3 && maxLineLength <= 6)
            {
                return sizeOfText * 7;
            }

            return sizeOfText * 6;        
        }
    }
}
