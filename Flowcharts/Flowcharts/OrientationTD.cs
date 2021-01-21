using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrientationTB : IOrientation
    {
        int Column;
        int Row;

        (double x, double y) In;
        (double x, double y) Out;

        public OrientationTB(){}

        public void Initialize(int Column, int Row, (double x, double y) In, (double x, double y) Out, int columnSize, int rowSize)
        {
            this.Column = Column;
            this.Row = Row;
            this.In = In;
            this.Out = Out;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (Row, Column);
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut(double rectangleXPos, double rectangleYPos, int rectangleWidth, int rectangleHeight)
        {
            In = (rectangleXPos + rectangleWidth / 2, rectangleYPos - 4);
            Out = (rectangleXPos + rectangleWidth / 2, rectangleYPos + rectangleHeight);

            return (In, Out);
        }
    }
}
