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

        public (IOPoints, double textAlignment) Draw()
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacing(orientation).GetSpacing();

            lines = new SplitText(text).GetLines();
            var numberOfLines = lines.Length;

            (rhombusSize, _) = GetSize();

            var maxline = lines.Max(x => x.Length);

            var (Column, Row) = orientation.GetColumnRow(); 

            xPos = distanceFromEdge + Column * unitLength + unitLength / 2;// astea trebuie schimbate
            yPos = distanceFromEdge + Row * unitHeight - unitHeight / 4 ; //pot sa dau ca forma sa dea pozitia scrisului pentru ca la celelalte se raporteaza la inaltime, da asta nu are o inaltime anume
            // sau pot sa fac sa fie incadradrat textul intr-un rectangle si acest rectangle sa fie in romb
            (In, Out) = GetInOut();
            DrawFigure();

            return (new IOPoints(In, Out), rhombusSize);
        }

        public IOPoints DrawFigure()
        {
           return new ShapeRhombusDrawn(xmlWriter, orientation, xPos, yPos, rhombusSize).Draw();
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            return new ShapeRhombusIO(orientation, xPos, yPos, rhombusSize).GetIO();
        }

        public (double height, double length) GetSize()
        {
            (double height, double length) = new ShapeRectangleSize(text).GetSize();
            return (height, length);
        }
    }
}