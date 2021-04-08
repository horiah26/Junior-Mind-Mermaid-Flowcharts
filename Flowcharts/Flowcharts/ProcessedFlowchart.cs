namespace Flowcharts
{
    public class ProcessedFlowchart
    {
        IGrid grid;
        readonly ArrowRegister arrowRegister;
        readonly ElementRegister elementRegister;

        public ProcessedFlowchart(IGrid grid, ArrowRegister arrowRegister, ElementRegister elementRegister)
        {
            this.grid = grid;
            this.arrowRegister = arrowRegister;
            this.elementRegister = elementRegister;
        }

        public void Process()
        {
            grid = GridOperations.DictionaryToGrid(elementRegister);

            var organizedGrid = GridOperations.OrganizedGrid(grid);
            var orderedArrows = Factory.OrderedArrows(arrowRegister);
            var drawnFlowchart = Factory.DrawnFlowchart(organizedGrid, orderedArrows);
            drawnFlowchart.Draw();
        }
    }
}