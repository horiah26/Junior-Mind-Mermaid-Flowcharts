using System;
using System.Linq;

namespace Flowcharts
{
    class TextSizeCalculator
    {
        readonly string[] lines;

        public TextSizeCalculator(string[] lines)
        {
            this.lines = lines;
        }

        public double Calculate()
        {
            double totalSize = 0;
            var sizeList = new TextSizeList().GetList();

            var maxLine = lines.OrderByDescending(x => x.Length).First();

            foreach(var character in maxLine)
            {
                bool found = false;

                foreach(var pair in sizeList)
                {
                    if(pair.letter == character)
                    {
                        totalSize += pair.value;
                    }

                    found = true;
                }

                if (!found)
                {
                    totalSize += 3;
                }
            }

            return Convert.ToInt32(Math.Ceiling(totalSize));
        }
    }
}