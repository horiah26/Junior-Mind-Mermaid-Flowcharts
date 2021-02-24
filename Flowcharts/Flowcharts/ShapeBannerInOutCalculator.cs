using System;

namespace Flowcharts
{
    internal class ShapeBannerInOutCalculator
    {
        private IOrientation orientation;
        private double xPos;
        private double yPos;
        private double bannerHeight;
        private double bannerLength;

        public ShapeBannerInOutCalculator(IOrientation orientation, double xPos, double yPos, double bannerHeight, double bannerLength)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.bannerHeight = bannerHeight;
            this.bannerLength = bannerLength;
        }

        public EntryExitPoints GetInOut()
        {
            (double x, double y) In;
            (double x, double y) Out;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 12 + bannerLength/5, yPos + bannerHeight / 2);
                Out = (xPos + bannerLength, yPos + 20);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + bannerLength + 5, yPos + bannerHeight / 2);
                Out = (xPos + bannerLength/5, yPos + bannerHeight / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + bannerLength / 2, yPos - 4);
                Out = (xPos + bannerLength / 2, yPos + bannerHeight);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + bannerLength / 2, yPos + bannerHeight + 4);
                Out = (xPos + bannerLength / 2, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new EntryExitPoints(In, Out);
        }
    }
}