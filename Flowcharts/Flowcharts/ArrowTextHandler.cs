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
            (string[] lines, _) = new TextSplitter(text).Split();

            Draw();
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

        public void Draw()
        {
            new ShapeArrowRectangle(fromElement.orientation, xmlWriter, fromElement, toElement, text).Draw();
        }
    }
}