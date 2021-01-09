using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    public class Grid
    {
        private int rowSize = 10;
        private int columnSize = 10;

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

        public void LowerColumnFromPosition(int row, int column, int positions)
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

        public void UpdateRows()
        {
            for (int i = 0; i < columnSize; i++)
            {
                UpdateRowsInColumn(i);
            }
        }

        public void UpdateRowsInColumn(int column)
        {
            for (int i = 0; i < rowSize; i++)
            {
                if (elementGrid[i, column] != null)
                {
                    elementGrid[i, column].Row = i;
                }
            }
        }

        public void ArrangeRows(int lastColumn)
        {
            for (int column = columnSize - 1; column >= 0; column--)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    if (elementGrid[row, column] != null)
                    {
                        MoveColumnInPlace(elementGrid[row, column], row, column);
                    }
                }

                UpdateRows();
            }

            LevelLastColumn(lastColumn);
            UpdateRows();
        }

        private void MoveColumnInPlace(Element element, int row, int column)
        {
            int average = GetAverageRowOfChildren(element);
            int difference = average - row;
            if (difference > 0)
            {
                LowerColumnFromPosition(row, column, difference);
            }

        }

        private int GetAverageRowOfChildren(Element element)
        {
            if (element.childElements.Count != 0)
            {
                return (int)Math.Round(element.childElements.Average(x => x.Row));
            }

            return element.Row;
        }

        private void LevelLastColumn(int lastColumn)
        {
            for (int i = 0; i < rowSize; i++)
            {
                if (elementGrid[i, lastColumn] != null)
                {
                    int average = GetAverageRowOfParents(elementGrid[i, lastColumn]);
                    int difference = average - i - 1;
                    if (difference > 0)
                    {
                        LowerColumnFromPosition(i, lastColumn, difference);
                    }
                }
            }
        }

        private int GetAverageRowOfParents(Element element)
        {
            if (element.parentElements.Count != 0)
            {
                return (int)Math.Round(element.parentElements.Average(x => x.Row));
            }

            return element.Row;
        }
    }
}