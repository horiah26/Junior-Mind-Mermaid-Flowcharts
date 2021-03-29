using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ElementArrayWithRaisedColumn
    {
        readonly Grid grid;
        Element[,] elementArray;
        readonly double row;
        readonly int column;
        readonly int positions;

        public ElementArrayWithRaisedColumn(Grid grid, double row, int column, int positions)
        {
            elementArray = grid.elementArray;
            this.grid = grid;
            this.row = row;
            this.column = column;
            this.positions = positions;
        }

        private void RaiseColumn()
        {

        }

        public Element[,] GetNewGrid()
        {
            RaiseColumn();
            return elementArray;
        }
    }
}
