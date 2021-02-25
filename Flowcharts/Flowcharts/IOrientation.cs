namespace Flowcharts
{
    public interface IOrientation
    {
        public void Initialize(int Column, int Row, int columnSize, int rowSize);
        public (int Column, int Row) GetColumnRow();
    }
}