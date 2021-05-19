using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    public class DrawnSubsystem
    {
        Subsystem subsystem;
        Element[,] ElementArray;
        readonly XmlWriter xmlWriter = Writer.XmlWriter;


        public DrawnSubsystem(Subsystem subsystem, Element[,] ElementArray)
        {
            this.subsystem = subsystem;
            this.ElementArray = ElementArray;
        }

        public void Draw()
        {
            (int lowestRow, int lowestColumn, int highestRow, int highestColumn) = subsystem.GetSubsystemLocation(ElementArray);
            var orientation = StaticOrientation.Orientation;
            orientation.Initialize(lowestColumn, lowestRow, ElementArray.GetLength(1), ElementArray.GetLength(0));
            (lowestColumn, lowestRow) = orientation.GetColumnRow();

            orientation.Initialize(highestColumn, highestRow, ElementArray.GetLength(1), ElementArray.GetLength(0));
            (highestColumn, highestRow) = orientation.GetColumnRow();

            (int distanceFromEdge, int unitLength, int unitHeight) = GridSpacing.GetSpacing();

            (double xPos, double yPos) cornerLeftUp = (distanceFromEdge + (lowestColumn) * unitLength, distanceFromEdge + (lowestRow - 0.5) * unitHeight);
            (double xPos, double yPos) cornerLeftDown = (distanceFromEdge + (lowestColumn) * unitLength, distanceFromEdge + (highestRow + 0.5) * unitHeight);
            (double xPos, double yPos) cornerRightUp = (distanceFromEdge + (highestColumn + 1) * unitLength, distanceFromEdge + (lowestRow - 0.5) * unitHeight);
            (double xPos, double yPos) cornerRightDown = (distanceFromEdge + (highestColumn + 1) * unitLength, distanceFromEdge + (highestRow + 0.5) * unitHeight);

            var coordinates = cornerLeftUp.xPos.ToString() + "," + cornerLeftUp.yPos.ToString() + " " + cornerLeftDown.xPos.ToString() + "," + cornerLeftDown.yPos.ToString()
                + " " + cornerRightDown.xPos.ToString() + "," + cornerRightDown.yPos.ToString() + " " + cornerRightUp.xPos.ToString() + "," + cornerRightUp.yPos.ToString();

            xmlWriter.WriteStartElement("polygon");
            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:red;stroke-width:3");
            xmlWriter.WriteEndElement();
        }
    }
}
