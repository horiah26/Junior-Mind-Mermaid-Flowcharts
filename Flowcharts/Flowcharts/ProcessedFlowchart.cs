using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class ProcessedFlowchart
    {
        Grid grid;
        readonly ArrowRegister arrowRegister;
        readonly ElementRegister elementRegister;

        public ProcessedFlowchart(Grid grid, ArrowRegister arrowRegister, ElementRegister elementRegister)
        {
            this.grid = grid;
            this.arrowRegister = arrowRegister;
            this.elementRegister = elementRegister;
        }

        public void Process()
        {
            grid = GridOperations.CreateGrid(elementRegister);

            var organizedGrid = GridOperations.CreateOrganizedGrid(grid, arrowRegister);
            var orderedArrows = Factory.CreateOrderedArrows(arrowRegister);
            var drawnFlowchart = Factory.CreateDrawnFlowchart(organizedGrid, orderedArrows);
            drawnFlowchart.Draw();
        }
    }
}