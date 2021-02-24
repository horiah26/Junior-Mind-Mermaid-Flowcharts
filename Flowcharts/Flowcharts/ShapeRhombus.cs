using System;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class ShapeRhombus : IShape
    {
        public int rectangleLength = 0;
        public int distanceFromEdge;
        public int unitLength;
        public int unitHeight;


        public double xPos;
        public double yPos;
        public double rhombusSize;

        public XmlWriter xmlWriter;
        public IOrientation orientation;
        public string[] lines;

        EntryExitPoints InOut;

        public ShapeRhombus()
        {
        }

        public (EntryExitPoints, int textAlignment) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;

            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();
            
            (string[] lines, int numberOfLines) = new TextSplitter(Text).Split();
            this.lines = lines;

            rhombusSize = GetSize();

            var maxline = lines.Max(x => x.Length);

            var (Column, Row) = orientation.GetColumnRow(); 

            xPos = distanceFromEdge + Column * unitLength + (unitLength - rhombusSize/3) / 2 + maxline * 4/3 - (numberOfLines - 1) * 7;
            yPos = distanceFromEdge + Row * unitHeight - rhombusSize/2 +  numberOfLines * 5;

            InOut = DrawFigure();

            return (InOut, rectangleLength);
        }

        public virtual EntryExitPoints DrawFigure()
        {
           return new ShapeRhombusDrawer(xmlWriter, orientation, xPos, yPos, rhombusSize).Draw();
        }

        public virtual double GetSize()
        {
           return new ShapeRhombusSizeCalculator(lines).Calculate();
        }
    }
}