namespace Flowcharts
{
    class ShapePolygonPosition
    {
        readonly IOrientation orientation;
        readonly string[] lines;

        (int Column, int Row) position;

        public ShapePolygonPosition(IOrientation orientation, (int Column, int Row) position, string[] lines)
        {
            this.orientation = orientation;
            this.position = position;
            this.lines = lines;
        }

        public virtual (double xPos, double yPos) GetPosition()
        {
            (int distanceFromEdge, int unitLength, int unitHeight) = new GridSpacing(orientation).GetSpacing();
            var length = new ShapeLengthCalculator(lines).GetLength();

            double xPos = distanceFromEdge + position.Column * unitLength + (unitLength - length) / 2;
            double yPos = distanceFromEdge + position.Row * unitHeight - 17;

            return (xPos, yPos);
        }
    }
}
