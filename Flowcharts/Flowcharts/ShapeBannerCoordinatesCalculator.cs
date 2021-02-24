using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeBannerCoordinatesCalculator
    {
        private double xPos;
        private double yPos;
        private double bannerHeight;
        private double bannerLength;

        public ShapeBannerCoordinatesCalculator(double xPos, double yPos, double bannerHeight, double bannerLength)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.bannerHeight = bannerHeight;
            this.bannerLength = bannerLength;
        }

        internal string Calculate()
        {
            //string arrowUp = (xPos - bannerLength/5).ToString() + "," + yPos.ToString();
            //string arrowMiddle = xPos.ToString() + "," + (yPos + bannerHeight / 2).ToString();
            //string arrowDown = (xPos - bannerLength / 5).ToString() + "," + (yPos + bannerHeight).ToString();
            //string down = (xPos + bannerLength).ToString() + "," + (yPos + bannerHeight).ToString();
            //string up = (xPos + bannerLength).ToString() + "," + (yPos).ToString();

            string arrowUp = (xPos).ToString() + "," + yPos.ToString();
            string arrowMiddle = (xPos + bannerLength/5).ToString() + "," + (yPos + bannerHeight / 2).ToString();
            string arrowDown = (xPos ).ToString() + "," + (yPos + bannerHeight).ToString();
            string down = (xPos + bannerLength).ToString() + "," + (yPos + bannerHeight).ToString();
            string up = (xPos + bannerLength).ToString() + "," + (yPos).ToString();

            //return arrowUp + " " + arrowDown + " " + down + " " + up;

            return arrowUp + " " + arrowMiddle + " " + arrowDown + " " + down + " " + up;
        }
    }
}
