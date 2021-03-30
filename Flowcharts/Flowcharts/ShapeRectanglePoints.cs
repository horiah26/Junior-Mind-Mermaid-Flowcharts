namespace Flowcharts
{
    class ShapeRectanglePoints
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeRectanglePoints(double xPos, double yPos, double height, double length)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        internal string GetPoints()
        {
            string leftUp = (xPos).ToString() + "," + (yPos + height / 2).ToString();
            string leftDown = (xPos).ToString() + "," + (yPos - height / 2).ToString();

            string rightUp = (xPos + length).ToString() + "," + (yPos + height / 2).ToString();
            string rightDown = (xPos + length).ToString() + "," + (yPos - height / 2).ToString();

            return rightUp + " " + rightDown + " " + leftDown + " " + leftUp;
        } 
    }
}