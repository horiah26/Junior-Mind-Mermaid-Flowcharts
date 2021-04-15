namespace Flowcharts
{
    class ShapePolygonPosition
    {
        readonly string[] lines;

        (int Column, int Row) position;

        public ShapePolygonPosition((int Column, int Row) position, string[] lines)
        {
            this.position = position;
            this.lines = lines;
        }

        public virtual (double xPos, double yPos) GetPosition()
        {
            (int distanceFromEdge, int unitLength, int unitHeight) = ElementOperations.GetSpacing();
            var length = TextOperations.CalculateLength(lines);

            double xPos = distanceFromEdge + position.Column * unitLength + (unitLength - length) / 2;
            double yPos = distanceFromEdge + position.Row * unitHeight - 17;

            return (xPos, yPos);
        }
    }
}
