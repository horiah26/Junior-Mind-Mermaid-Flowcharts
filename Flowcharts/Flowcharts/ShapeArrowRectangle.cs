
namespace Flowcharts
{
    public class ShapeArrowRectangle : ShapePolygon
    {

        public ShapeArrowRectangle(string text, double xPos, double yPos) : base(text)
        {
            this.text = text;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public override (double xPos, double yPos) CalculatePosition()
        {
            return (xPos - 10, yPos + lines.Length * 7 - 12);
        }

        public override void Color()
        {
            xmlWriter.WriteAttributeString("style", "fill: rgb(220, 220, 220); stroke-width: 4; stroke: rgb(255, 255, 255)");
        }
    }    
}
