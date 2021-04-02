namespace Flowcharts
{
    class ShapeHexagonPoints
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        readonly string[] lines;

        public ShapeHexagonPoints(double xPos, double yPos, double height, double length, string[] lines)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.lines = lines;
        }

        internal string GetPoints()
        {
            int numberOfLines = lines.Length;

            string rightUp = (xPos).ToString() + "," + (yPos - height / 2).ToString();
            string rightMiddle = (xPos - numberOfLines * 10).ToString() + "," + yPos.ToString();
            string rightDown = (xPos).ToString() + "," + (yPos + height / 2).ToString();

            string leftUp = (xPos + length).ToString() + "," + (yPos - height / 2).ToString();
            string leftMiddle = (xPos + numberOfLines * 10 + length).ToString() + "," + yPos.ToString();
            string leftDown = (xPos + length).ToString() + "," + (yPos + height / 2).ToString();

            return rightUp + " " + rightMiddle + " " + rightDown + " " + leftDown + " " + leftMiddle + " " + leftUp;
        }
    }
}