namespace Flowcharts
{
    internal class ShapeCirclePositionCalculator
    {
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;
        int xPos;
        int yPos;
        readonly IOrientation orientation;
        readonly string text;
        readonly int radius;

        public ShapeCirclePositionCalculator(IOrientation orientation, string text, int radius)
        {
            this.orientation = orientation;
            this.text = text;
            this.radius = radius;
        }

        public (int xPos, int yPos) Calculate()
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();

            (_, int numberOfLines) = new TextSplitter(text).Split();

            var (Column, Row) = orientation.GetColumnRow();

            if (text.Length == 1)
            {
                xPos = distanceFromEdge + Column * unitLength + unitLength / 2 + 5;
                yPos = distanceFromEdge + Row * unitHeight + numberOfLines * 5 - 3;
            }
            else
            {
                xPos = distanceFromEdge + Column * unitLength + unitLength / 2 + radius / 4 + 5;
                yPos = distanceFromEdge + Row * unitHeight + numberOfLines * 5;
            }

            return (xPos, yPos);
        }
    }
}