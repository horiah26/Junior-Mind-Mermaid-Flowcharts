﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Flowcharts
{
    class TextSizeCalculator
    {
        string[] lines;

        public TextSizeCalculator(string[] lines)
        {
            this.lines = lines;
        }

        public int Calculate()
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
                    totalSize += 1;
                }
            }

            return Convert.ToInt32(totalSize);
        }
    }
}
