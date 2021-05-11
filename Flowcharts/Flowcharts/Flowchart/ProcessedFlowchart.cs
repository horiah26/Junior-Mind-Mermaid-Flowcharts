namespace Flowcharts
{
    public class ProcessedFlowchart
    {
        IGrid grid;
        readonly ArrowRegister arrowRegister;
        readonly ElementRegister elementRegister;
        DrawnFlowchart drawnFlowchart;

        public ProcessedFlowchart(IGrid grid, ArrowRegister arrowRegister, ElementRegister elementRegister)
        {
            this.grid = grid;
            this.arrowRegister = arrowRegister;
            this.elementRegister = elementRegister;
        }

        public (IGrid grid, IArrowRegister orderedArrows) Process()
        {
            grid = GridOperations.DictionaryToGrid(elementRegister);

            var organizedGrid = GridOperations.OrganizedGrid(grid);
            var orderedArrows = Factory.OrderedArrows(arrowRegister);
            drawnFlowchart = Factory.DrawnFlowchart(organizedGrid, orderedArrows);

            return (organizedGrid, orderedArrows);
        }

        public void Draw()
        {
            Process();
            drawnFlowchart.Draw();
        }
    }
}