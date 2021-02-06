using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrientationLeftRIght : IOrientation
    {
        int Column;
        int Row;
        int rowSize;

        (double x, double y) In;
        (double x, double y) Out;

        public OrientationLeftRIght(){}

        public void Initialize(int Column, int Row, (double x, double y) In, (double x, double y) Out, int columnSize, int rowSize) 
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
    }
}
