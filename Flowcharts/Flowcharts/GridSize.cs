namespace Flowcharts
{
    class GridSize
    {
        readonly Grid grid;
        int RowSize;
        int ColumnSize;

        public GridSize(Grid grid)
        {
            this.grid = grid;
        }

        public (int rowSize, int columnSize) GetSize()
        {
            RowSize = grid.elementArray.GetLength(0);
            ColumnSize = grid.elementArray.GetLength(1);

            return (RowSize, ColumnSize);
        }
    }
}