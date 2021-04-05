namespace Flowcharts
{
    public interface IShape
    {
        public (IOPoints, double textAlignment) Draw();

        public (double height, double length) GetSize();
    }
}