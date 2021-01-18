using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrientationRL : IOrientation
    {
        int Column;
        int Row;
        int columnSize;

        (double x, double y) In;
        (double x, double y) Out;

        public OrientationRL(int Column, int Row, (double x, double y) In, (double x, double y) Out, int columnSize, int rowSize)
        {
            this.Column = Column;
            this.Row = Row;
            this.In = In;
            this.Out = Out;
            this.columnSize = columnSize;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (columnSize - Column - 1, Row);
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut(double rectangleXPos, double rectangleYPos, int rectangleWidth, int rectangleHeight)
        {
            Out = (rectangleXPos - 5, rectangleYPos + rectangleHeight / 2);
            In = (rectangleXPos + rectangleWidth, rectangleYPos + 20);

            return (In, Out);
        }
    }
}