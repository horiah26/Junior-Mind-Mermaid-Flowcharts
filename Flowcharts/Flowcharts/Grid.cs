using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    public class Grid
    {
        private int rowSize = 10;
        private int columnSize = 10;
        private int lastOccupiedColumn = 0;

        public Element[,] elementGrid;

        public Grid()
        {
            elementGrid = new Element[rowSize, columnSize];
        }

        public void Add(Element element, int row, int column)
        {
            if (column >= columnSize)
            {
                elementGrid = ResizeArray(elementGrid, rowSize, column + 1);
            }
            if (row >= rowSize)
            {
                elementGrid = ResizeArray(elementGrid, row + 1, columnSize);
            }

            if (elementGrid[row, column] != null)
            {
                throw new InvalidOperationException("Element occupied");
            }

            elementGrid[row, column] = element;

        }

        public IEnumerator<Element> GetEnumerator()
        {
            foreach (Element element in elementGrid)
            {
                if (element != null)
                {
                    yield return element;
                }
            }
        }

        public (int, int) Dimensions()
        {
            return (rowSize, columnSize);
        }

        public Element ElementAt(int row, int column)
        {
            return elementGrid[row, column];
        }

        public void LowerColumnInGrid(double row, int column, int positions)
        {
            if (positions == 0)
            {
                return;
            }

            IEnumerable<Element> extractedColumn = GetColumn(column);

            int emptyPositionsAtTheEnd = extractedColumn.Reverse().TakeWhile(x => x == null).Count();

            int difference = positions - emptyPositionsAtTheEnd;

            if (difference > 0)
            {
                elementGrid = ResizeArray(elementGrid, rowSize + difference, columnSize);
            }

            for (int i = rowSize - 1; i >= row; i--)
            {
                if (elementGrid[i, column] != null)
                {
                    if (elementGrid[i + positions, column] != null)
                    {
                        throw new InvalidOperationException("Cannot move. Space is not empty");
                    }

                    elementGrid[i + positions, column] = elementGrid[i, column];
                    elementGrid[i, column] = null;
                }
            }
        }

        public (int row, int column) FindElementCoordinates(string text) 
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    if (elementGrid[i, j] != null && text.Equals(elementGrid[i, j].Text))
                    {
                        return (i, j);
                    }
                }
            }

            throw new InvalidOperationException("Element dos not exist");
        }

        public IEnumerable<Element> GetColumn(int column)
        {
            List<Element> extractedColumn = new List<Element> { };

            for (int i = 0; i < columnSize; i++)
            {
                extractedColumn.Add(elementGrid[i, column]);
            }

            return extractedColumn;
        }

        Element[,] ResizeArray<Element>(Element[,] original, int rows, int columns)
        {
            var newArray = new Element[rows, columns];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(columns, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];

            if (columnSize < columns)
            {
                columnSize = columns;
            }
            if (rowSize < rows)
            {
                rowSize = rows;
            }

            return newArray;
        }

        public void ActualizeElements()
        {
            for (int i = 0; i < columnSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    if (elementGrid[i, j] != null)
                    {
                        elementGrid[i, j].Row = i;
                        elementGrid[i, j].Column = j;
                    }
                }
            }
        }

        public void ArrangeRows()
        {
            for (int column = lastOccupiedColumn; column >= 0; column--)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    if (elementGrid[row, column] != null)
                    {
                        MoveColumnInPlace(row, column);
                    }
                }

                ActualizeElements();
            }

            LevellastOccupiedColumn();
            ActualizeElements();
        }

        private void MoveColumnInPlace(int row, int column)
        {            
            double average = GetAverageRowOfChildren(elementGrid[row, column]);
            int difference = (int)average - row;
            if (difference > 0)
            {
                LowerColumnInGrid(row, column, difference);
            }
        }

        private double GetAverageRowOfChildren(Element element)
        {
            if (element.childElements.Count != 0)
            {
                return (int)Math.Floor(element.childElements.Average(x => x.Row));
            }

            return element.Row;
        }

        public void AlignColumns()
        {
            IEnumerable<Element> elementsInColumn = new List<Element> { };
            IEnumerable<Element> elementsInNextColumn = GetColumn(lastOccupiedColumn).Where(x => x != null);

            for (int column = lastOccupiedColumn - 1; column >= 0; column--)
            {
                elementsInColumn = GetColumn(column).Where(x => x != null);

                var averageRowThis = elementsInColumn.Average(x => x.Row);
                var averageRowNext = elementsInNextColumn.Average(x => x.Row);

                var difference = averageRowThis - averageRowNext;           
                var roundedDIfference = Math.Round(difference * 2, MidpointRounding.AwayFromZero) / 2;

                foreach(var element in elementsInColumn)
                {
                    element.Row -= roundedDIfference;
                }

                elementsInNextColumn = elementsInColumn;
            }
            LevellastOccupiedColumn();
        }

        public void LevellastOccupiedColumn()
        {
            var lastColumn = GetColumn(lastOccupiedColumn).Where(x => x != null);

            var averageParents = lastColumn.Average(x => GetAverageRowOfParents(x));

            for (int i = 0; i < rowSize; i++)
            {
                if (elementGrid[i, lastOccupiedColumn] != null)
                {
                    var average = GetAverageRowOfParents(elementGrid[i, lastOccupiedColumn]);
                    int difference = (int)average - i - 1;
                    if (difference > 0)
                    {
                        LowerColumnInGrid(i, lastOccupiedColumn, difference);
                    }
                }
            }
        }

        private double GetAverageRowOfParents(Element element)
        {
            if (element.parentElements.Count != 0)
            {
                return (int)Math.Round(element.parentElements.Average(x => x.Row));
            }

            return element.Row;
        }
           
        public void FillEmptySpots()
        {
            for (int column = lastOccupiedColumn - 2; column >= 0; column--)
            {
                for (int row = 0; row < rowSize; row++)
                {                
                    if (elementGrid[row, column] != null && elementGrid[row, column + 1] == null && elementGrid[row, column].MinColumnOfChildren() - 1> column)
                    {
                        elementGrid[row, column].MinColumnOfChildren();
                        elementGrid[row, column + 1] = elementGrid[row, column];

                        elementGrid[row, column] = null;
                        ActualizeElements();
                    }
                }
            }

            ActualizeElements(); 
        } 

        public void ArrangeAll(int lastOccupiedColumn)
        {
            this.lastOccupiedColumn = lastOccupiedColumn;

            ActualizeElements();
            ArrangeRows();
            FillEmptySpots();
        }
    }
}