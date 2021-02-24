using System.Xml;
using System.Linq;

namespace Flowcharts
{
    class ArrowTextHandler
    {
        readonly XmlWriter xmlWriter;
        readonly Element fromElement;
        readonly Element toElement;
        readonly string text;

        public ArrowTextHandler(XmlWriter xmlWriter, Element fromElement, Element toElement, string text)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.text = text;
        }

        public void DrawAndWrite() 
        {
            (string[] lines,int numberOfLines) = new TextSplitter(text).Split();

            Draw(numberOfLines, lines);
            WriteText(lines);
        }

        public void WriteText(string[] lines)
        {
            int maxLineLength = lines.Max(x => x.Length);
            double xPosition = (fromElement.Out.x + toElement.In.x - maxLineLength * 7) / 2;
            double yPosition = (fromElement.Out.y + toElement.In.y - lines.Length * 5) / 2;

            TextWriter textWriter = new TextWriter(xmlWriter, xPosition, yPosition, lines);
            textWriter.Write();
        }

        public void Draw(int numberOfLines, string[] lines)
        {
            new ShapeArrowRectangle(fromElement.orientation, fromElement, toElement, numberOfLines, lines).Draw(xmlWriter, fromElement.orientation, text);
        }
    }
}