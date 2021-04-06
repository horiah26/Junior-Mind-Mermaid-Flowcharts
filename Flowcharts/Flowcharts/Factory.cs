using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    public static class Factory
    {
        public static Grid CreateGrid()
        {
            return new Grid();
        }

        public static ArrowRegister CreateArrowRegister()
        {
            return new ArrowRegister();
        }

        public static ElementRegister CreateElementRegister()
        {
            return new ElementRegister();
        }

        public static DrawnFlowchart CreateDrawnFlowchart(MemoryStream MemoryStream, Grid Grid, ArrowRegister arrowRegister, ElementRegister elementRegister)
        {
            return new DrawnFlowchart(MemoryStream, Grid, arrowRegister, elementRegister);
        }

        public static IArrow CreateIArrow(string arrowName, Element element1, Element element2, string text)
        {
            var arrowType = Type.GetType("Flowcharts." + arrowName);
            return (IArrow)Activator.CreateInstance(arrowType, new object[] { element1, element2, text });
        }

        public static Element CreateElement(string key, string text, string shape)
        {
            return new Element(key, text, shape);
        }
    }
}
