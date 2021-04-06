using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public static class Orientation
    {
        public static string OrientationName { get; private set; }

        static public bool SetOrientation(string orientationName)
        {
            OrientationName = orientationName;
            return true;
        }

    }
}
