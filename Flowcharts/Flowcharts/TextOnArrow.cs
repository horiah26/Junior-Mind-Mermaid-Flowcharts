using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class TextOnArrow
    {
        readonly double xPosition;
        readonly double yPosition;
        readonly string text;

        public TextOnArrow(double xPosition, double yPosition, string text)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.text = text;
        }

        public void DrawAndWrite()
        {
            Draw();
            WriteText();
        }

        public void WriteText()
        {
            var lines = TextOperations.SplitText(text);
            WrittenText writtenText = new WrittenText(xPosition, yPosition, lines);
            writtenText.Write();
        }

        public void Draw()
        {
            new ShapeArrowRectangle(text, xPosition, yPosition).Draw();
        }
    }
}
