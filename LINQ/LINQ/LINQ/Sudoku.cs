using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class Sudoku
    {
        public static bool IsSudoku(IEnumerable<IEnumerable<int>> tableAsRows)
        {
            var RowsColumnsSquares = tableAsRows.Concat(GetColumns(tableAsRows).Concat(GetSquares(tableAsRows)));

            return AllCombinationsAreSudoku(RowsColumnsSquares);
        }

        private static IEnumerable<IEnumerable<int>> GetColumns(IEnumerable<IEnumerable<int>> sudoku)
        {
            return Enumerable.Range(0, 9).Select(x => sudoku.Select(row => row.ElementAt(x)));
        }

        private static IEnumerable<IEnumerable<int>> GetSquares(IEnumerable<IEnumerable<int>> sudoku)
        {
            var cornerPoints = new List<int> { 0, 3, 6, 27, 30, 33, 54, 57, 60 };
            var smallSquareCoordinates = new List<int> { 0, 1, 2, 9, 10, 11, 18, 19, 20 };

            var flattenedSudoku = sudoku.SelectMany(x => x);

            return cornerPoints.SelectMany(x => smallSquareCoordinates, (corner, coordinates) => (corner, coordinates))
                                .GroupBy(x => x.corner)
                                .Select(x => x.Select(square => flattenedSudoku.ElementAt(square.corner + square.coordinates)));
        }

        private static bool AllCombinationsAreSudoku(IEnumerable<IEnumerable<int>> Lists)
        {
            int[] oneToNine = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            return Lists.Select(row => row.OrderBy(x => x).SequenceEqual(oneToNine)).All(x => x == true);
        }
    }
}
