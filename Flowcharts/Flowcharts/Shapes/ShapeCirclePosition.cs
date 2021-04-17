namespace Flowcharts
{
    internal class ShapeCirclePosition
    {
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;
        double xPos;
        double yPos;
        readonly IOrientation orientation = StaticOrientation.Orientation;

        public ShapeCirclePosition()
        {            
        }

        public (double xPos, double yPos) GetPosition()
        {
            (distanceFromEdge, unitLength, unitHeight) = ElementOperations.GetSpacing();

            var (Column, Row) = orientation.GetColumnRow();

            xPos = distanceFromEdge + Column * unitLength + unitLength / 2;
            yPos = distanceFromEdge + Row * unitHeight - 16;
        
            return (xPos, yPos);
        }
    }
}