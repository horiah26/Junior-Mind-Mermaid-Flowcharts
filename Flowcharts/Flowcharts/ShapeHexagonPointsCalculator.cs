namespace Flowcharts
{
    class ShapeHexagonPointsCalculator
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        readonly string[] lines;

        public ShapeHexagonPointsCalculator(double xPos, double yPos, double height, double length, string[] lines)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.lines = lines;
        }

        internal string Calculate()
        {
            int numberOfLines = lines.Length;

            string rightUp = (xPos).ToString() + "," + yPos.ToString();
            string rightMiddle = (xPos - numberOfLines * 10).ToString() + "," + (yPos + height / 2).ToString();
            string rightDown = (xPos).ToString() + "," + (yPos + height).ToString();

            string leftUp = (xPos + length).ToString() + "," + yPos.ToString();
            string leftMiddle = (xPos + numberOfLines * 10 + length).ToString() + "," + (yPos + height / 2).ToString();
            string leftDown = (xPos + length).ToString() + "," + (yPos + height).ToString();

            return rightUp + " " + rightMiddle + " " + rightDown + " " + leftDown + " " + leftMiddle + " " + leftUp;
        }
    }
}