namespace Flowcharts
{
    internal class ShapeCirclePosition
    {
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;
        double xPos;
        double yPos;
        readonly IOrientation orientation;
        readonly string text;
        readonly double radius;

        public ShapeCirclePosition(IOrientation orientation, string text, double radius)
        {
            this.orientation = orientation;
            this.text = text;
            this.radius = radius;
        }

        public (double xPos, double yPos) GetPosition()
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacing(orientation).GetSpacing();

            var (Column, Row) = orientation.GetColumnRow();

            xPos = distanceFromEdge + Column * unitLength + unitLength / 2;
            yPos = distanceFromEdge + Row * unitHeight - 16;
        
            return (xPos, yPos);
        }
    }
}