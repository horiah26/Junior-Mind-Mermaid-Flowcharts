﻿using System;
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

        public OrientationRL(){}
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
            return (columnSize - Column - 1, Row);
        }
    }
}