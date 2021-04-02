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
            double linesAdjustment = (numberOfLines - 1) * 10;

            double maxDimension = length > height ? length + linesAdjustment * 1.5 : height + linesAdjustment * 1.5;

            string up = (xPos + maxDimension / 2 - linesAdjustment / 2).ToString() + "," + (yPos - maxDimension / 2).ToString();
            string down = (xPos + maxDimension / 2 - linesAdjustment / 2).ToString() + "," + (yPos + maxDimension / 2).ToString();

            string left = (xPos - linesAdjustment / 2).ToString() + "," + (yPos).ToString();
            string right = (xPos + maxDimension - linesAdjustment / 2).ToString() + "," + (yPos).ToString();

            return up + " " + left + " " + down + " " + right;
        }
    }
}