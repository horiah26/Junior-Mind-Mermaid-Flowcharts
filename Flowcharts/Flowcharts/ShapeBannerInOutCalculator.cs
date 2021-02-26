﻿using System;

namespace Flowcharts
{
    internal class ShapeBannerInOutCalculator
    {
        private readonly IOrientation orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeBannerInOutCalculator(IOrientation orientation, double xPos, double yPos, double height, double length)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public EntryExitPoints CalculateInOut()
        {
            (double x, double y) In;
            (double x, double y) Out;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 20, yPos + height / 2);
                Out = (xPos + length - length/5, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length - length / 5 + 3, yPos + height / 2);
                Out = (xPos - 10, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2 - 15 - length / 10, yPos - 4);
                Out = (xPos + length / 2 - 15 - length / 10, yPos + height);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2 - 15 - length / 10, yPos + height + 4);
                Out = (xPos + length / 2 - 15 - length / 10, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new EntryExitPoints(In, Out);
        }
    }
}