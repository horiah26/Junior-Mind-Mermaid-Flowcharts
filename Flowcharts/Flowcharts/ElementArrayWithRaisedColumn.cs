namespace Flowcharts
{
    class ElementArrayWithRaisedColumn
    {
        readonly Grid grid;
        readonly Element[,] ElementArray;
        readonly double row;
        readonly int column;
        readonly int positions;

        public ElementArrayWithRaisedColumn(Grid grid, double row, int column, int positions)
        {
            ElementArray = grid.ElementArray;
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
            return ElementArray;
        }
    }
}
