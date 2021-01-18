using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class SelectOrientation
    {
        private IOrientation orientationClass;

        public SelectOrientation(string orientation, int Column, int Row, (double x, double y) In, (double x, double y) Out, int columnSize, int rowSize, int lastOccupiedColumn)
        {
            switch (orientation)
            {
                case "LR":
                    orientationClass = new OrientationLR(Column, Row, In, Out, columnSize, rowSize);
                    break;
                case "RL":
                    orientationClass = new OrientationRL(Column, Row, In, Out, columnSize, rowSize);
                    break;
                case "TB":
                    orientationClass = new OrientationTB(Column, Row, In, Out, columnSize, rowSize);
                    break;
                case "BT":
                    orientationClass = new OrientationBT(Column, Row, In, Out, columnSize, rowSize);
                    break;
            }
        }

        public (int Column, int Row) GetColumnRow()
        {
           return orientationClass.GetColumnRow();
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut(double rectangleXPos, double rectangleYPos, int rectangleWidth, int rectangleHeight)
        {
            return orientationClass.GetInOut(rectangleXPos, rectangleYPos, rectangleWidth, rectangleHeight);
        }
    }
}
