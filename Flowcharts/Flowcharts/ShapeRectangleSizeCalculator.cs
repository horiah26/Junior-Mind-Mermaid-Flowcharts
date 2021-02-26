using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeRectangleSizeCalculator
    {
        readonly string text;

        public ShapeRectangleSizeCalculator(string text)
        {
            this.text = text;
        }

        public double height;
        public double length;

        public (double height, double length) Calculate()
        {
            (string[] lines, int numberOfLines) = new TextSplitter(text).Split();

            height = 40 + (numberOfLines - 1) * 17;
            length = new ShapelengthCalculator(lines).Calculate();

            return (height, length);
        }
    }
}
