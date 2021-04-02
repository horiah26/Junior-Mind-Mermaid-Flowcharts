using System;

namespace Flowcharts
{
    class ShapeRhombusIO
    {
        (double x, double y) In;
        (double x, double y) Out;
        (double x, double y) BackArrowEntry;

        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;

        readonly double height;
        readonly double length;
        int numberOfLines;

        public ShapeRhombusIO(IOrientation orientation, double xPos, double yPos, double height, double length, string[] lines)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.numberOfLines = lines.Length;
        }

        public IOPoints GetIO()
        {
            double linesAdjustment = (numberOfLines - 1) * 10;
            double maxDimension = length > height ? length + linesAdjustment * 2 : height + linesAdjustment * 2;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - linesAdjustment / 2 - 5, yPos);
                Out = (xPos + length / 2, yPos);

                BackArrowEntry = (xPos + maxDimension - linesAdjustment, yPos);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + maxDimension - linesAdjustment + 5, yPos);
                Out = (xPos + length / 2, yPos);

                BackArrowEntry = (xPos - linesAdjustment - 10, yPos);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + maxDimension / 2 - linesAdjustment, yPos - maxDimension / 2 - 5);
                Out = (xPos + maxDimension / 2 - linesAdjustment, yPos);

                BackArrowEntry = (xPos + maxDimension / 2 - linesAdjustment, yPos + maxDimension / 2);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos, yPos + height + 3);
                Out = (xPos, yPos);

                BackArrowEntry = (xPos + length + linesAdjustment, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new IOPoints(In, Out, BackArrowEntry);
        }
    }
}
