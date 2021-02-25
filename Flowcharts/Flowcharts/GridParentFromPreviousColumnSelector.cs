using System.Collections.Generic;

namespace Flowcharts
{
    class GridParentFromPreviousColumnSelector
    {
        readonly Grid grid;

        public GridParentFromPreviousColumnSelector(Grid grid)
        {
            this.grid = grid;
        }

        public void Select()
        {
            for (int column = grid.lastOccupiedColumn; column >= 0; column--)
            {
                for (int row = 0; row < grid.rowSize; row++)
                {
                    var element = grid.elementGrid[row, column];
                    if (element != null)
                    {
                        List<Element> newParents = new List<Element> { };

                        foreach (var parent in element.parentElements)
                        {
                            if (parent.Column < element.Column)
                            {
                                newParents.Add(parent);
                            }

                            element.parentElements = newParents;
                        }

                        foreach (var child in element.childElements)
                        {
                            if (child.Column <= element.Column)
                            {
                                element.parentElements.Remove(child);
                            }
                        }
                    }
                }
            }
        }
    }
}