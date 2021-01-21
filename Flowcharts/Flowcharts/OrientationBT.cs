using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrientationBT : IOrientation
    {
        int Column;
        int Row;
        int columnSize;

        (double x, double y) In;
        (double x, double y) Out;

        public OrientationBT() { }
        public void Initialize(int Column, int Row, (double x, double y) In, (double x, double y) Out, int columnSize, int rowSize)
        {
            this.Column = Column;
            this.Row = Row;
            this.In = In;
            this.Out = Out;
            this.columnSize = columnSize;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (Row, columnSize - Column - 1);
        }

        ((double x, double y) In, (double x, double y) Out) IOrientation.GetInOut(double rectangleXPos, double rectangleYPos, int rectangleWidth, int rectangleHeight)
        {
            Out = (rectangleXPos + rectangleWidth / 2, rectangleYPos - 4);
            In = (rectangleXPos + rectangleWidth / 2, rectangleYPos + rectangleHeight);

            return (In, Out);
        }
    }
}
