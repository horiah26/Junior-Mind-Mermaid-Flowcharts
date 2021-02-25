namespace Flowcharts
{
    class OrientationLeftRight : IOrientation
    {
        int Column;
        int Row;

        public OrientationLeftRight(){}

        public void Initialize(int Column, int Row, int columnSize, int rowSize) 
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
