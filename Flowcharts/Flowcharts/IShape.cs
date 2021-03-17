using System.Xml;

namespace Flowcharts
{
    interface IShape
    {
        public (IOPoints, double textAlignment) Draw();
    }
}