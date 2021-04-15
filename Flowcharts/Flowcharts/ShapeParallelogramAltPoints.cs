namespace Flowcharts
{
    internal class ShapeParallelogramAltPoints
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        readonly double gap;

        public ShapeParallelogramAltPoints(double xPos, double yPos, double height, double length, double gap)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.gap = gap;
        }

        internal string GetPoints()
        {
            string leftUp = (xPos - gap).ToString() + "," + (yPos - height / 2).ToString();
            string leftDown = (xPos).ToString() + "," + (yPos + height / 2).ToString();

            string rightUp = (xPos + length).ToString() + "," + (yPos - height / 2).ToString();
            string rightDown = (xPos + length + gap).ToString() + "," + (yPos + height / 2).ToString();

            return rightUp + " " + rightDown + " " + leftDown + " " + leftUp;
        }
    }
}