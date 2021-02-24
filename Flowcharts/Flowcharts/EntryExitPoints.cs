using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class EntryExitPoints
    {
        public (double x, double y) In;
        public (double x, double y) Out;
        public EntryExitPoints((double x, double y) In, (double x, double y) Out)
        {
            this.In = In;
            this.Out = Out;
        }
    }
}
