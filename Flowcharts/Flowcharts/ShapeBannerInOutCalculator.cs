﻿using System;

namespace Flowcharts
{
    internal class ShapeBannerInOutCalculator
    {
        private IOrientation orientation;
        private double xPos;
        private double yPos;
        private double height;
        private double length;

        public ShapeBannerInOutCalculator(IOrientation orientation, double xPos, double yPos, double height, double length)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public EntryExitPoints GetInOut()
        {
            (double x, double y) In;
            (double x, double y) Out;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 12 + length/5, yPos + height / 2);
                Out = (xPos + length, yPos + 20);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 5, yPos + height / 2);
                Out = (xPos + length/5, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - 4);
                Out = (xPos + length / 2, yPos + height);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height + 4);
                Out = (xPos + length / 2, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new EntryExitPoints(In, Out);
        }
    }
}