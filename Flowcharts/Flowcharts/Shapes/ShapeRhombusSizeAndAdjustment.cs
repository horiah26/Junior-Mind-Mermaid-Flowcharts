namespace Flowcharts
{
    class ShapeRhombusSizeAndAdjustment
    {
        readonly double length;
        readonly double height;
        readonly int numberOfLines;

        public ShapeRhombusSizeAndAdjustment(double length, double height, string[] lines)
        {
            this.length = length;
            this.height = height;
            numberOfLines = lines.Length;
        }

        public ShapeRhombusSizeAndAdjustment(double length, double height, int numberOfLines)
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
