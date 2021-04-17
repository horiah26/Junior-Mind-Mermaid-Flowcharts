namespace Flowcharts
{
    class LinearizedGrid : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public LinearizedGrid(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            ElementArray = ArrayOperations.LevelColumns(ElementArray);
            ElementArray = ArrayOperations.ArrangeTwinSituations(ElementArray);
            ElementArray = ArrayOperations.LevelElementsIndividually(ElementArray);
        }                 
    }
}