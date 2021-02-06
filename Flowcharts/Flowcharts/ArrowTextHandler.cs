using System.Xml;

namespace Flowcharts
{
    class ArrowTextHandler
    {
        XmlWriter xmlWriter;
        Element fromElement;
        Element toElement;
        string text;

        public ArrowTextHandler(XmlWriter xmlWriter, Element fromElement, Element toElement, string text)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.text = text;
        }

        public void DrawAndWrite() 
        {
            (string[] lines,int numberOfLines) = new TextSplitter(text).SplitWords();

            Draw(numberOfLines, lines);
            WriteText(lines);
        }

        public void WriteText(string[] lines)
        {
            double xPosition = (fromElement.Out.x + toElement.In.x - (lines[0].Length - 0) * 10) / 2;
            double yPosition = (fromElement.Out.y + toElement.In.y - lines.Length * 5) / 2;

            TextWriter textWriter = new TextWriter(xmlWriter, xPosition, yPosition, lines);
            textWriter.Write();
        }

        public void Draw(int numberOfLines, string[] lines)
        {
            new ShapeArrowRectangle(xmlWriter, fromElement, toElement, numberOfLines, lines).Draw(xmlWriter, fromElement.orientation, text, numberOfLines);
        }
    }
}