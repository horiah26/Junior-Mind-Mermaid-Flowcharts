namespace Flowcharts
{
    class ShapeRhombusPoints
    {
        readonly double xPos;
        readonly double yPos;
        readonly double height;
        readonly double length;
        int numberOfLines;

        public ShapeRhombusPoints(double xPos, double yPos, double height, double length,int numberOfLines)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.numberOfLines = numberOfLines;
        }

        public string GetPoints()
        {
            (var linesAdjustment, var maxDimension,var correctionFactor) = new RhombusSizeAndAdjustment(length, height, numberOfLines).Get();

            string up = (xPos + maxDimension / 2 - linesAdjustment / correctionFactor).ToString() + "," + (yPos - maxDimension / 2).ToString();
            string down = (xPos + maxDimension / 2 - linesAdjustment / correctionFactor).ToString() + "," + (yPos + maxDimension / 2).ToString();

            string left = (xPos - linesAdjustment / correctionFactor).ToString() + "," + (yPos).ToString();
            string right = (xPos + maxDimension - linesAdjustment / correctionFactor).ToString() + "," + (yPos).ToString();

            return up + " " + left + " " + down + " " + right;
        }
    }
}