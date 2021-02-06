using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrientationRightLeft : IOrientation
    {
        int Column;
        int Row;
        int columnSize;

        public OrientationRightLeft(){}
        public void Initialize(int Column, int Row, int columnSize, int rowSize)
        {
            this.Column = Column;
            this.Row = Row;
            this.columnSize = columnSize;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (columnSize - Column - 1, Row);
        }
    }
}