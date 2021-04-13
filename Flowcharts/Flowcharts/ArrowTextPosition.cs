using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ArrowTextPosition : IArrowPosition
    {
        readonly Element fromElement;
        readonly Element toElement;
        readonly string[] lines;

        public ArrowTextPosition(Element fromElement, Element toElement, string[] lines)
        {
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.lines = lines;
        }

        public (double xPosition, double yPosition) GetCoordinates()
        {
            int maxLineLength = lines.Max(x => x.Length);
            double xPosition = (fromElement.Out.x + toElement.In.x - maxLineLength * 7) / 2;
            double yPosition = (fromElement.Out.y + toElement.In.y + 15 - lines.Length * 12) / 2;
            return (xPosition, yPosition);
        }
    }
}
