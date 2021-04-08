using System.Linq;

namespace Flowcharts
{
    internal class LinearGrid : IGrid
    {
        public Element[,] ElementArray { get; set; }

        public LinearGrid(IGrid grid)
        {
            ElementArray = grid.ElementArray;
            Linearize();
        }

        public void Linearize()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (ElementArray[j, i] != null && ElementArray[j, i].parentElements.Count == 1 && ElementArray[j, i].parentElements.First().childElements.Count == 1)
                    {
                        var element = ElementArray[j, i];
                        var newRow = element.parentElements.First().Row;
                        ElementArray[newRow, i] = ElementArray[j, i];
                    }

                    ArrayOperations.Update(ElementArray);
                }
            }
        }
    }
}