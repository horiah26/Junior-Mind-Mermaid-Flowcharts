namespace Flowcharts
{
    class OrientationLeftRight : IOrientation
    {
        int Column;
        int Row;

        public OrientationLeftRight(){}

        public void Initialize(int Column, int Row, int Columns, int Rows) 
        {
            this.Column = Column;
            this.Row = Row;
        }

        public (int Column, int Row) GetColumnRow()
        {
            return (Column, Row);
        }
    }
}
