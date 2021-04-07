using System;

namespace Flowcharts
{
    public static class Factory
    {
        public static Grid CreateGrid()
        {
            return new Grid();
        }

        public static ArrowRegister ArrowRegister()
        {
            return new ArrowRegister();
        }

        public static ElementRegister ElementRegister()
        {
            return new ElementRegister();
        }

        public static ProcessedFlowchart ProcessedFlowchart(Grid grid, ArrowRegister arrowRegister, ElementRegister elementRegister)
        {
            return new ProcessedFlowchart(grid, arrowRegister, elementRegister);
        }

        public static IArrow IArrow(string arrowName, Element element1, Element element2, string text)
        {
            var arrowType = Type.GetType("Flowcharts." + arrowName);
            return (IArrow)Activator.CreateInstance(arrowType, new object[] { element1, element2, text });
        }

        public static Element Element(string key, string text, string shape)
        {
            return new Element(key, text, shape);
        }

        public static OrderedArrows OrderedArrows(IArrowRegister arrowRegister)
        {
            return new OrderedArrows(arrowRegister);
        }

        public static DrawnFlowchart DrawnFlowchart(IGrid organizedGrid, OrderedArrows orderedArrows)
        {
            return new DrawnFlowchart(organizedGrid, orderedArrows);
        }
    }
}
