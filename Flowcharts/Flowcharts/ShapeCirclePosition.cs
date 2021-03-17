namespace Flowcharts
{
    internal class ShapeCirclePosition
    {
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;
        int xPos;
        int yPos;
        readonly IOrientation orientation;
        readonly string text;
        readonly int radius;

        public ShapeCirclePosition(IOrientation orientation, string text, int radius)
        {
            this.orientation = orientation;
            this.text = text;
            this.radius = radius;
        }

        public (int xPos, int yPos) GetPosition()
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacing(orientation).GetSpacing();

            var numberOfLines = new SplitText(text).GetLines().Length;

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