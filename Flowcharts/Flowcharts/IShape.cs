using System.Xml;

namespace Flowcharts
{
    interface IShape
    {
        public (EntryExitPoints, double textAlignment) Draw();
    }
}