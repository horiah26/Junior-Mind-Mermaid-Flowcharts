namespace Flowcharts
{
    class ShapeRectanglePointsCalculator
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeRectanglePointsCalculator(double xPos, double yPos, double height, double length)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        internal string Calculate()
        {
            string leftUp = (xPos).ToString() + "," + yPos.ToString();
            string leftDown = (xPos).ToString() + "," + (yPos + height).ToString();

            string rightUp = (xPos + length).ToString() + "," + yPos.ToString();
            string rightDown = (xPos + length).ToString() + "," + (yPos + height).ToString();

            return rightUp + " " + rightDown + " " + leftDown + " " + leftUp;
        } 
    }
}