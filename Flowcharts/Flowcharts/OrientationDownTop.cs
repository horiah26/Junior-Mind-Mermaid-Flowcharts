namespace Flowcharts
{
    class OrientationDownTop : IOrientation
    {
        int Column;
        int Row;
        int Columns;

        public OrientationDownTop() { }
        public void Initialize(int Column, int Row, int Columns, int Rows)
        {
            this.Column = Column;
            this.Row = Row;
            this.Columns = Columns;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (Row, Columns - Column - 1);
        }
    }
}
