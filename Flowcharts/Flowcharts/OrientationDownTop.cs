namespace Flowcharts
{
    class OrientationDownTop : IOrientation
    {
        int Column;
        int Row;
        int columnSize;

        public OrientationDownTop() { }
        public void Initialize(int Column, int Row, int columnSize, int rowSize)
        {
            this.Column = Column;
            this.Row = Row;
            this.columnSize = columnSize;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (Row, columnSize - Column - 1);
        }
    }
}
