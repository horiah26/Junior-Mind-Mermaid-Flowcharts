namespace Flowcharts
{
    class ShapeBannerPoints
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeBannerPoints(double xPos, double yPos, double height, double length)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        internal string GetPoints()
        {
            string arrowUp = (xPos - 30).ToString() + "," + (yPos - height / 2).ToString();
            string arrowMiddle = (xPos - 10).ToString() + "," + (yPos).ToString();
            string arrowDown = (xPos - 30).ToString() + "," + (yPos + height / 2).ToString();
            string down = (xPos + length - length / 5).ToString() + "," + (yPos + height / 2).ToString();
            string up = (xPos + length - length / 5).ToString() + "," + (yPos - height / 2).ToString();

            return arrowUp + " " + arrowMiddle + " " + arrowDown + " " + down + " " + up;
        }
    }
}
