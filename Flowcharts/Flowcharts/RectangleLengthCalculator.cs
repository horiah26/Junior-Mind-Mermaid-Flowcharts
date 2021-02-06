using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class RectangleLengthCalculator
    {
        public string[] lines;
        public RectangleLengthCalculator(string[] lines)
        {
            this.lines = lines;
        }

        public int Calculate()
        {
            var maxline = lines.Max(x => x.Length);

            if (maxline < 5)
            {
                return 3;
            }
            else if (maxline >= 5 && maxline < 10)
            {
                return 7;
            }
            else if (maxline >= 10 && maxline < 13)
            {
                return 12;
            }
            else if (maxline >= 13 && maxline < 15)
            {
                return 14;
            }
            else
            {
                return 18;
            }
        }
    }
}