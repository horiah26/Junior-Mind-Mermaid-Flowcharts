using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrientationDownTop : IOrientation
    {
        int Column;
        int Row;
        int columnSize;

        (double x, double y) In;
        (double x, double y) Out;

        public OrientationDownTop() { }
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
    }
}
