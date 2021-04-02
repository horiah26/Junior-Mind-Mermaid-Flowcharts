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
        string[] lines;

        public ShapeRhombusIO(IOrientation orientation, double xPos, double yPos, double height, double length, string[] lines)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.lines = lines;
        }

        public IOPoints GetIO()
        {
            (var linesAdjustment, var maxDimension, var correctionFactor) = new RhombusSizeAndAdjustment(length, height, lines).Get();

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - linesAdjustment / correctionFactor - 5, yPos);
                Out = (xPos + length / 2, yPos);

                BackArrowEntry = (xPos + maxDimension - linesAdjustment / correctionFactor, yPos);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + maxDimension - linesAdjustment / correctionFactor + 7, yPos);
                Out = (xPos + length / 2, yPos);

                BackArrowEntry = (xPos - linesAdjustment / correctionFactor, yPos);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + maxDimension / 2 - linesAdjustment / correctionFactor, yPos - maxDimension / 2 - 5);
                Out = (xPos + maxDimension / 2 - linesAdjustment / correctionFactor, yPos);

                BackArrowEntry = (xPos + maxDimension / 2 - linesAdjustment / correctionFactor, yPos + maxDimension / 2);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + maxDimension / 2 - linesAdjustment / correctionFactor, yPos + maxDimension / 2 + 5);
                Out = (xPos + maxDimension / 2 - linesAdjustment / correctionFactor, yPos);

                BackArrowEntry = (xPos + maxDimension / 2 - linesAdjustment / correctionFactor, yPos - maxDimension / 2 - 20);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new IOPoints(In, Out, BackArrowEntry);
        }
    }
}
