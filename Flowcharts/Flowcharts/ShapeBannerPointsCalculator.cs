namespace Flowcharts
{
    class ShapeBannerPointsCalculator
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeBannerPointsCalculator(double xPos, double yPos, double height, double length)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        internal string Calculate()
        {
            string arrowUp = (xPos - 30).ToString() + "," + yPos.ToString();
            string arrowMiddle = (xPos - 10).ToString() + "," + (yPos + height / 2).ToString();
            string arrowDown = (xPos - 30).ToString() + "," + (yPos + height).ToString();
            string down = (xPos + length - length / 5).ToString() + "," + (yPos + height).ToString();
            string up = (xPos + length - length / 5).ToString() + "," + (yPos).ToString();

            return arrowUp + " " + arrowMiddle + " " + arrowDown + " " + down + " " + up;
        }
    }
}
