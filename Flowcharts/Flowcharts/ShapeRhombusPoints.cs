namespace Flowcharts
{
    class ShapeRhombusPoints
    {
        readonly double xPos;
        readonly double yPos;
        readonly double rhombusSize;

        public ShapeRhombusPoints(double xPos, double yPos, double rhombusSize)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.rhombusSize = rhombusSize;
        }

        public string GetPoints()
        {
            string left = (xPos - rhombusSize / 2).ToString() + "," + (yPos + rhombusSize / 2).ToString();
            string down = (xPos).ToString() + "," + (yPos + rhombusSize).ToString();
            string up = (xPos).ToString() + "," + yPos.ToString();
            string right = (xPos + rhombusSize / 2).ToString() + "," + (yPos + rhombusSize / 2).ToString();

            return up + " " + left + " " + down + " " + right;
        }
    }
}