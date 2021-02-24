using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    interface IShape
    {
        public (EntryExitPoints, int textAlignment) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text);
    }
}