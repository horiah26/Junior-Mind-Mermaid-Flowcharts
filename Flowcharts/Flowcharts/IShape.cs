using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    interface IShape
    {
        public (EntryExitPoints, int dimension) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text);
    }
}