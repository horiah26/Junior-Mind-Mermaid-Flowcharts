using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ShapeRhombusSizeCalculator
    {
        string[] lines;

        public ShapeRhombusSizeCalculator(string[] lines)
        {
            this.lines = lines;
        }
        public double Calculate()
        {
            var maxline = lines.Max(x => x.Length);

            if (maxline < 2)
            {
                return 40;
            }
            else if (maxline >= 2 && maxline < 5)
            {
                return 68;
            }
            else if (maxline >= 5 && maxline < 7)
            {
                return 85;
            }
            else if (maxline >= 7 && maxline < 10)
            {
                return 100;
            }
            else if (maxline >= 10 && maxline < 13)
            {
                return 120;
            }
            else if (maxline >= 13 && maxline < 17)
            {
                return 150;
            }
            else
            {
                return 190;
            }
        }
    }
}
