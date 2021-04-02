using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class RhombusSizeAndAdjustment
    {
        double length;
        double height;
        int numberOfLines;

        public RhombusSizeAndAdjustment(double length, double height, string[] lines)
        {
            this.length = length;
            this.height = height;
            numberOfLines = lines.Length;
        }

        public RhombusSizeAndAdjustment(double length, double height, int numberOfLines)
        {
            this.length = length;
            this.height = height;
            this.numberOfLines = numberOfLines;
        }

        public (double linesAdjustment, double maxDimension, double correctionFactor) Get()
        {
            double correctionFactor = 1.5;
            var linesAdjustment = numberOfLines * 9;
            var maxDimension = length > height ? length + linesAdjustment * correctionFactor : height + linesAdjustment * correctionFactor;
            return (linesAdjustment, maxDimension, correctionFactor);
        }
    }
}
