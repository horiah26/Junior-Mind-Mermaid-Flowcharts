using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public static class ElementOperations
    {
        public static int MinColumnOfChildren(Element element)
        {
            return new MinimumColumnOfChildren(element).Get();
        }

        public static IOPoints Draw(IOrientation orientation, string text, string shapeName)
        {
            return new DrawnElement(orientation, text, shapeName).Draw();
        }
    }
}
