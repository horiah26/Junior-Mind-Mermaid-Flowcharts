using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrientationTopDown : IOrientation
    {
        int Column;
        int Row;

        (double x, double y) In;
        (double x, double y) Out;

        public OrientationTopDown(){}

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
    }
}
