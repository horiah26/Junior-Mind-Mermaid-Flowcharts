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

        public static IOPoints Draw(string text, Type shapeType)
        {
            return new DrawnElement(text, shapeType).Draw();
        }

        public static (int distanceFromEdge, int unitLength, int unitHeight) GetSpacing()
        {
            return new GridSpacing().GetSpacing();
        }
        
        public static IOPoints CreateIO((double x, double y) In, (double x, double y) Out, (double x, double y) BackArrowLeft, (double x, double y) BackArrowRight)
        {
            return new IOPoints(In,  Out,  BackArrowLeft,  BackArrowRight);
        }
    
    }
}
