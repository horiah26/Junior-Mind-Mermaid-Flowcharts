﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    public class Grid
    {
        public int rowSize = 1;
        public int columnSize = 1;
        public int lastOccupiedColumn;

        public Element[,] elementGrid;

        public Grid()
        {
            elementGrid = new Element[rowSize, columnSize];
        }

        public void Add(Element element, int row, int column)
        {
            new GridElementAdder(this).Add(element, row, column);
        }

        public (int, int) GetDimensions()
        {
            return (rowSize, columnSize);
        }

        public Element ElementAt(int row, int column)
        {
            return elementGrid[row, column];
        }

        public void LowerColumnInGrid(double row, int column, int positions)
        {
            new GridColumnLowerer(this).LowerColumnInGrid(row, column, positions);
        }

        public void UpdateElementsPosition()
        {
            new GridElementActualizer(this).Actualize();
        }

        public void ArrangeRows()
        {
            new GridRowArranger(this).ArrangeRows();
        }

        public void FillEmptySpots()
        {
            new GridEmptySpotsFiller(this).FillEmptySpots();
        }

        public void AdjustForBackArrows(List<Arrow> arrows)
        {
            new GridBackArrowAdjuster(this).AdjustForBackArrows(arrows);
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

        public void ArrangeAll(List<Arrow> arrows)
        {
            lastOccupiedColumn = new GridLastOccupiedColumnFinder(this).GetLastColumn();

            UpdateElementsPosition();
            ArrangeRows();
            FillEmptySpots();
            AdjustForBackArrows(arrows);
            UpdateElementsPosition();
        }
    }
}