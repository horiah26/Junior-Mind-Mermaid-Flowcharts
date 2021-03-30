namespace Flowcharts
{
    class ShapeSubroutinePoints
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeSubroutinePoints(double xPos, double yPos, double height, double length)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        internal string GetPoints()
        {
            double widthOfEdge = 7;

            string OuterLeftUp = (xPos - widthOfEdge).ToString() + "," + yPos.ToString();
            string OuterLeftDown = (xPos - widthOfEdge).ToString() + "," + (yPos + height).ToString();

            string OuterRightUp = (xPos + length + widthOfEdge).ToString() + "," + yPos.ToString();
            string OuterRightDown = (xPos + length + widthOfEdge).ToString() + "," + (yPos + height).ToString();

            string InnerLeftUp = (xPos).ToString() + "," + yPos.ToString();
            string InnerLeftDown = (xPos).ToString() + "," + (yPos + height).ToString();

            string InnerRightUp = (xPos + length).ToString() + "," + yPos.ToString();
            string InnerRightDown = (xPos + length).ToString() + "," + (yPos + height).ToString();

            return InnerRightUp + " " + InnerRightDown + " " + InnerLeftDown + " " + InnerLeftUp + " " + OuterLeftUp + " " + OuterLeftDown + " " + OuterRightDown + " " + OuterRightUp + " " + OuterLeftUp;
        }
    }
}