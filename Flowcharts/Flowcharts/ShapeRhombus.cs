using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class ShapeRhombus : IShape
    {
        public int length = 0;
        public int distanceFromEdge;
        public int unitLength;
        public int unitHeight;

        public double xPos;
        public double yPos;
        public double rhombusSize;

        public XmlWriter xmlWriter;
        public IOrientation orientation;
        public string[] lines;

        readonly string text;

        (double x, double y) In;
        (double x, double y) Out; 

        public ShapeRhombus(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;
            this.text = text;
        }

        public (EntryExitPoints, double textAlignment) Draw()
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();
            
            (string[] lines, int numberOfLines) = new TextSplitter(text).Split();
            this.lines = lines;

            rhombusSize = GetSize();

            var maxline = lines.Max(x => x.Length);

            var (Column, Row) = orientation.GetColumnRow(); 

            xPos = distanceFromEdge + Column * unitLength + (unitLength - rhombusSize/3) / 2 + maxline * 4/3 - (numberOfLines - 1) * 7;
            yPos = distanceFromEdge + Row * unitHeight - rhombusSize/2 +  numberOfLines * 5;

            (In, Out) = GetInOut();
            DrawFigure();

            return (new EntryExitPoints(In, Out), rhombusSize);
        }

        public virtual EntryExitPoints DrawFigure()
        {
           return new ShapeRhombusDrawer(xmlWriter, orientation, xPos, yPos, rhombusSize).Draw();
        }

        public virtual double GetSize()
        {
           return new ShapeRhombusSizeCalculator(lines).Calculate();
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            return new ShapeRhombusInOutCalculator(orientation, xPos, yPos, rhombusSize).CalculateInOut();
        }
    }
}