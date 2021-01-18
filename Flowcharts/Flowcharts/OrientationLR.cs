using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrientationLR : IOrientation
    {
        int Column;
        int Row;

        int rowSize;

        (double x, double y) In;
        (double x, double y) Out;

        public OrientationLR(int Column, int Row, (double x, double y) In, (double x, double y) Out, int columnSize, int rowSize) 
        {
            this.Column = Column;
            this.Row = Row;
            this.In = In;
            this.Out = Out;
            this.rowSize = rowSize;            
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (Column, Row);
        }

        ((double x, double y) In, (double x, double y) Out) IOrientation.GetInOut(double rectangleXPos, double rectangleYPos, int rectangleWidth, int rectangleHeight)
        {
            In = (rectangleXPos - 5, rectangleYPos + rectangleHeight / 2);
            Out = (rectangleXPos + rectangleWidth, rectangleYPos + 20);

            return (In, Out);
        }
    }
}
