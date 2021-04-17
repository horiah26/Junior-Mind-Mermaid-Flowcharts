using System;

namespace Flowcharts
{
    public static class StaticOrientation
    {
        public static string OrientationName { get; private set; }
        public static IOrientation Orientation { get; private set; }
  
        static public void SetOrientation(string orientationName)
        {
            OrientationName = orientationName;
            Type orientationType = Type.GetType("Flowcharts.Orientation" + OrientationName);
            Orientation = (IOrientation)Activator.CreateInstance(orientationType);
        }
    }
}
