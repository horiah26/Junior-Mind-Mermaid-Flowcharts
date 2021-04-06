namespace Flowcharts
{
    public interface IOrientation
    {
        public void Initialize(int Column, int Row, int Columns, int Rows);
        public (int Column, int Row) GetColumnRow();
    }
}