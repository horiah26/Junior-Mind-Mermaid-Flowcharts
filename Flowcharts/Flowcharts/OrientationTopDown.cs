namespace Flowcharts
{
    class OrientationTopDown : IOrientation
    {
        int Column;
        int Row;

        public OrientationTopDown(){}

        public void Initialize(int Column, int Row, int Columns, int Rows)
        {
            this.Column = Column;
            this.Row = Row;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (Row, Column);
        }
    }
}
