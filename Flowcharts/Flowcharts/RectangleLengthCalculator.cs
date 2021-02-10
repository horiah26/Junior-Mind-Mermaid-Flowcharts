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

            if (maxline < 3)
            {
                return 3;
            }
            else if (maxline >= 3 && maxline < 5)
            {
                return 5;
            }
            else if (maxline >= 5 && maxline < 7)
            {
                return 7;
            }
            else if (maxline >= 7 && maxline < 10)
            {
                return 10;
            }
            else if (maxline >= 10 && maxline < 13)
            {
                return 13;
            }
            else if (maxline >= 13 && maxline < 15)
            {
                return 15;
            }
            else if (maxline >= 15 && maxline < 17)
            {
                return 17;
            }
            else
            {
                return 19;
            }
        }
    }
}