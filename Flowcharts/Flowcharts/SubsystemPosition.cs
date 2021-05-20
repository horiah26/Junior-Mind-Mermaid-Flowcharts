using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class SubsystemPosition
    {
        Element[,] ElementArray;
        Subsystem subsystem;
        public SubsystemPosition(Element[,] ElementArray, Subsystem subsystem)
        {
            this.ElementArray = ElementArray;
            this.subsystem = subsystem;
        }

        public SubsystemCoordinates GetCoordinates()
        {
            (int lowestRow, int lowestColumn, int highestRow, int highestColumn) = subsystem.GetSubsystemLocation(ElementArray);
            (int distanceFromEdge, int unitLength, int unitHeight) = GridSpacing.GetSpacing();

            var orientation = StaticOrientation.Orientation;

            orientation.Initialize(lowestColumn, lowestRow, ElementArray.GetLength(1), ElementArray.GetLength(0));
            (lowestColumn, lowestRow) = orientation.GetColumnRow();
            orientation.Initialize(highestColumn, highestRow, ElementArray.GetLength(1), ElementArray.GetLength(0));
            (highestColumn, highestRow) = orientation.GetColumnRow();


            if(typeof(OrientationLeftRight) == orientation.GetType() || typeof(OrientationTopDown) == orientation.GetType())
            {
                (double xPos, double yPos) cornerLeftUp = (distanceFromEdge + (lowestColumn) * unitLength, distanceFromEdge + (lowestRow - 0.5) * unitHeight);
                (double xPos, double yPos) cornerLeftDown = (distanceFromEdge + (lowestColumn) * unitLength, distanceFromEdge + (highestRow + 0.5) * unitHeight);
                (double xPos, double yPos) cornerRightUp = (distanceFromEdge + (highestColumn + 1) * unitLength, distanceFromEdge + (lowestRow - 0.5) * unitHeight);
                (double xPos, double yPos) cornerRightDown = (distanceFromEdge + (highestColumn + 1) * unitLength, distanceFromEdge + (highestRow + 0.5) * unitHeight);

                (double xPos, double yPos) textPosition = (cornerLeftUp.xPos, cornerLeftUp.yPos - 20);

                return new SubsystemCoordinates(cornerLeftUp, cornerLeftDown, cornerRightUp, cornerRightDown, textPosition);
            }
            else if(typeof(OrientationRightLeft) == orientation.GetType())
            {
                (double xPos, double yPos) cornerLeftUp = (distanceFromEdge + (lowestColumn) * unitLength, distanceFromEdge + (lowestRow - 0.5) * unitHeight);
                (double xPos, double yPos) cornerLeftDown = (distanceFromEdge + (lowestColumn) * unitLength, distanceFromEdge + (highestRow + 0.5) * unitHeight);
                (double xPos, double yPos) cornerRightUp = (distanceFromEdge + (highestColumn ) * unitLength, distanceFromEdge + (lowestRow - 0.5) * unitHeight);
                (double xPos, double yPos) cornerRightDown = (distanceFromEdge + (highestColumn) * unitLength, distanceFromEdge + (highestRow + 0.5) * unitHeight);

                (double xPos, double yPos) textPosition = (cornerRightUp.xPos, cornerRightUp.yPos - 20);

                return new SubsystemCoordinates(cornerLeftUp, cornerLeftDown, cornerRightUp, cornerRightDown, textPosition);
            }
            else
            {
                (double xPos, double yPos) cornerLeftUp = (distanceFromEdge + (lowestColumn) * unitLength, distanceFromEdge + (lowestRow - 0.5) * unitHeight);
                (double xPos, double yPos) cornerLeftDown = (distanceFromEdge + (lowestColumn) * unitLength, distanceFromEdge + (highestRow - 0.5) * unitHeight);
                (double xPos, double yPos) cornerRightUp = (distanceFromEdge + (highestColumn + 1) * unitLength, distanceFromEdge + (lowestRow - 0.5) * unitHeight);
                (double xPos, double yPos) cornerRightDown = (distanceFromEdge + (highestColumn + 1) * unitLength, distanceFromEdge + (highestRow - 0.5) * unitHeight);

                (double xPos, double yPos) textPosition = (cornerLeftDown.xPos, cornerLeftDown.yPos - 20);
                return new SubsystemCoordinates(cornerLeftUp, cornerLeftDown, cornerRightUp, cornerRightDown, textPosition);
            }
        }
    }
}
