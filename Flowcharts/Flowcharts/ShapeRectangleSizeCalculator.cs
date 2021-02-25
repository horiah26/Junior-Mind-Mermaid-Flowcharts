using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeRectangleSizeCalculator
    {
        string text;

        public ShapeRectangleSizeCalculator(string text)
        {
            this.text = text;
        }

        public int rectangleHeight;
        public int rectangleLength;

        public (int rectangleHeight, int rectangleLength) Calculate()
        {
            (string[] lines, int numberOfLines) = new TextSplitter(text).Split();

            rectangleHeight = 40 + (numberOfLines - 1) * 17;
            rectangleLength = new ShapeRectangleLengthCalculator(lines).Calculate();

            return (rectangleHeight, rectangleLength);
        }
    }
}
