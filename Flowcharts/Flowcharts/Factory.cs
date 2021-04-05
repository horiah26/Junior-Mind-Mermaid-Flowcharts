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

        public static ElementRegister CreateElementRegister(XmlWriter xmlWriter, string orientationName)
        {
            return new ElementRegister(xmlWriter, orientationName);
        }

        public static DrawnFlowchart CreateDrawnFlowchart(XmlWriter xmlWriter,MemoryStream MemoryStream, Grid Grid, ArrowRegister arrowRegister, ElementRegister elementRegister)
        {
            return new DrawnFlowchart(xmlWriter, MemoryStream, Grid, arrowRegister, elementRegister);
        }

        public static IArrow CreateIArrow(XmlWriter xmlWriter, string arrowName, Element element1, Element element2, string text)
        {
            var arrowType = Type.GetType("Flowcharts." + arrowName);
            return (IArrow)Activator.CreateInstance(arrowType, new object[] { xmlWriter, element1, element2, text });
        }

        public static Element CreateElement(XmlWriter xmlWriter, string key, string text, string shape, string orientationName)
        {
            return new Element(xmlWriter, key, text, shape, orientationName);
        }
    }
}
