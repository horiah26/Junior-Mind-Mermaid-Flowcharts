using System.Xml;

namespace Flowcharts
{
    interface IShape
    {
        public (EntryExitPoints, int textAlignment) Draw();
    }
}