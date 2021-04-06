namespace Flowcharts
{
    class OrientationRightLeft : IOrientation
    {
        int Column;
        int Row;
        int Columns;

        public OrientationRightLeft(){}
        public void Initialize(int Column, int Row, int Columns, int Rows)
        {
            this.Column = Column;
            this.Row = Row;
            this.Columns = Columns;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (Columns - Column - 1, Row);
        }
    }
}