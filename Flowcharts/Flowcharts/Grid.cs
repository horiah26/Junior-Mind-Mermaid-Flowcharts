using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    public class Grid
    {
        private int rowSize = 1;
        private int columnSize = 1;
        private int lastOccupiedColumn = 0;

        public Element[,] elementGrid;

        public Grid()
        {
            elementGrid = new Element[rowSize, columnSize];
        }

        public void Add(Element element, int row, int column)
        {
            if (column > columnSize - 1)
            {
                elementGrid = ResizeArray(elementGrid, rowSize, column + 1);
            }
            if (row > rowSize - 1)
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

        public IEnumerable<Element> GetColumn(int column)
        {
            List<Element> extractedColumn = new List<Element> { };

            for (int i = 0; i < rowSize; i++)
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
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
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

        public void LevellastOccupiedColumn()
        {
            var lastColumn = GetColumn(lastOccupiedColumn).Where(x => x != null);

            var averageParents = lastColumn.Average(x => GetAverageRowOfParents(x));
            var averageThis = lastColumn.Average(x => x.Row);
                
            for (int i = (int)Math.Floor(averageParents); i < rowSize; i++)
            {
                if (elementGrid[i, lastOccupiedColumn] != null)
                {
                    int difference = (int)averageParents - i;
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

        public void SelectParentsFromPreviousColumn()
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

        public void AdjustForBackArrows(List<Arrow> arrows)
        {
            List<(double row, int forwardColum, int backColumn)> backArrowCoordinates = new List<(double row, int forwardColum, int backColumn)> { };

            UpdateListOfBackArrows(ref backArrowCoordinates, arrows);
       
            foreach (var element in this)
            {
                UpdateListOfBackArrows(ref backArrowCoordinates, arrows);
                foreach (var (row, forwardColum, backColumn) in backArrowCoordinates)
                {
                    if (element.Row == row && backColumn < element.Column && element.Column < forwardColum)
                    {                       
                        LowerColumnInGrid(element.Row, element.Column, 1);
                        ActualizeElements();
                    }
                }
            }
        }

        private void UpdateListOfBackArrows(ref List<(double row, int forwardColum, int backColumn)> backArrowCoordinates, List<Arrow> arrows)
        {
            List<(double row, int forwardColum, int backColumn)> tempCoordinates = new List<(double row, int forwardColum, int backColumn)> { };

            foreach (var backArrow in arrows)
            {   
                if(typeof(BackArrow) == backArrow.GetType())

                if (typeof(BackArrow) == backArrow.GetType() && backArrow.fromElement.Row == backArrow.toElement.Row)
                {
                    tempCoordinates.Add((backArrow.fromElement.Row, backArrow.fromElement.Column, backArrow.toElement.Column));
                }
            }

            backArrowCoordinates = tempCoordinates;
        }

        public void SendArraySizeToElements()
        {
            foreach(var element in this)
            {
                element.columnSize = columnSize;
                element.rowSize = rowSize;
            }
        }

        public void ArrangeAll(List<Arrow> arrows, int lastOccupiedColumn)
        {
            this.lastOccupiedColumn = lastOccupiedColumn;

            //SelectParentsFromPreviousColumn();
            //ActualizeElements();
            ArrangeRows();
            FillEmptySpots();
            AdjustForBackArrows(arrows);
            SendArraySizeToElements();
            ActualizeElements();
            Console.WriteLine();
        }
    }
}