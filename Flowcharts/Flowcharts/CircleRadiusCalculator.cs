using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class CircleRadiusCalculator
    {
        string text;
        public CircleRadiusCalculator(string text) 
        {
            this.text = text;
        }

        public int Calculate()
        {
            (string[] lines,int numberOfLines) = new TextSplitter(text).Split();

            var maxline = lines.Max(x => x.Length);

            if (maxline < 5)
            {
                return 20 + numberOfLines * 2;
            }
            else if (maxline >= 5 && maxline < 10)
            {
                return 40 + numberOfLines * 2;
            }
            else if (maxline >= 10 && maxline < 13)
            {
                return 60 + numberOfLines * 2;
            }
            else if (maxline >= 13 && maxline < 18)
            {
                return 65 + numberOfLines * 2;
            }
            else
            {
                return 80 + numberOfLines * 2;
            }
        }
    }
}
