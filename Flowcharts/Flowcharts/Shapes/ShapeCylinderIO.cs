﻿using System;

namespace Flowcharts
{
    internal class ShapeCylinderIO
    {
        private readonly IOrientation orientation = StaticOrientation.Orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        private readonly int numberOfLines;

        public ShapeCylinderIO(double xPos, double yPos, double height, double length, int numberOfLines)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.numberOfLines = numberOfLines;
        }

        public IOPoints GetIO()
        {
            (double x, double y) In;
            (double x, double y) Out;
            (double x, double y) BackArrowLeft;
            (double x, double y) BackArrowRight;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 5, yPos + height / 2);
                Out = (xPos + length, yPos + height / 2);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2.5);
                BackArrowRight = (xPos + length / 2, yPos + height + 10);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 5, yPos + height / 2);
                Out = (xPos, yPos + height / 2);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2.5);
                BackArrowRight = (xPos + length / 2, yPos + height + 10);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - 23 - numberOfLines * 4);
                Out = (xPos + length / 2, yPos + height + 10);

                BackArrowLeft = (xPos, yPos + height/ 2);
                BackArrowRight = (xPos + length, yPos + height / 2);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height + 15);
                Out = (xPos + length / 2, yPos - height * 0.25 - 10);


                BackArrowLeft = (xPos, yPos + height / 2);
                BackArrowRight = (xPos + length, yPos + height / 2);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return ElementOperations.CreateIO(In, Out, BackArrowLeft, BackArrowRight);
        }
    }
}