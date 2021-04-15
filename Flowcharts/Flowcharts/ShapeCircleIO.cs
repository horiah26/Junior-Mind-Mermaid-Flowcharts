using System;

namespace Flowcharts
{
    class ShapeCircleIO
    {
        (double x, double y) In;
        (double x, double y) Out;
        (double x, double y) BackArrowLeft;
        (double x, double y) BackArrowRight;

        readonly IOrientation orientation = StaticOrientation.Orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double radius;

        public ShapeCircleIO(double xPos, double yPos, double radius)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.radius = radius;
        }

        public IOPoints GetIO()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - radius - 3, yPos);
                Out = (xPos + radius, yPos);

                BackArrowLeft = (xPos, yPos - radius);
                BackArrowRight = (xPos, yPos + radius);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + radius + 5, yPos);
                Out = (xPos - radius, yPos);

                BackArrowLeft = (xPos, yPos - radius);
                BackArrowRight = (xPos, yPos + radius);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos, yPos - radius - 4);
                Out = (xPos, yPos + radius);
                BackArrowLeft = (xPos - radius, yPos);
                BackArrowRight = (xPos + radius, yPos);
            }        
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                Out = (xPos, yPos - radius);
                In = (xPos, yPos + radius + 4);

                BackArrowLeft = (xPos - radius, yPos);
                BackArrowRight = (xPos + radius, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return ElementOperations.CreateIO(In, Out, BackArrowLeft, BackArrowRight);
        }
    }
}
