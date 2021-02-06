using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridParentFromPreviousColumnSelector
    {
        int lastOccupiedColumn;
        int rowSize;
        Element[,] elementGrid;

        public GridParentFromPreviousColumnSelector(Grid grid)
        {
            lastOccupiedColumn = grid.lastOccupiedColumn;
            rowSize = grid.rowSize;
            elementGrid = grid.elementGrid;
        }

        public void Select()
        {
            for (int column = lastOccupiedColumn; column >= 0; column--)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    var element = elementGrid[row, column];
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