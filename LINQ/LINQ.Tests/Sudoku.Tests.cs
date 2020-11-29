using System.Collections.Generic;
using Xunit;

namespace LINQ.Tests
{
    public class SudokuTests
    {
        [Fact]
        public void SudokuWorksShouldReturnTrue()
        {
            int[] row1 = new int[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 };
            int[] row2 = new int[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 };
            int[] row3 = new int[] { 1, 9, 7, 8, 3, 4, 5, 6, 2 };
            int[] row4 = new int[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 };
            int[] row5 = new int[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 };
            int[] row6 = new int[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 };
            int[] row7 = new int[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 };
            int[] row8 = new int[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 };
            int[] row9 = new int[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 };

            var sudokuTable = new List<int[]> { row1, row2, row3, row4, row5, row6, row7, row8, row9 };

            Assert.True(Sudoku.IsSudoku(sudokuTable));
        }

        [Fact]
        public void SudokuWorksShouldReturnFalse()
        {
            int[] row1 = new int[] { 1, 3, 5, 2, 6, 9, 7, 8, 1 }; // changed element at position 0 to 1
            int[] row2 = new int[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 };
            int[] row3 = new int[] { 1, 9, 7, 8, 3, 4, 5, 6, 2 };
            int[] row4 = new int[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 };
            int[] row5 = new int[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 };
            int[] row6 = new int[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 };
            int[] row7 = new int[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 };
            int[] row8 = new int[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 };
            int[] row9 = new int[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 };

            var sudokuTable = new List<int[]> { row1, row2, row3, row4, row5, row6, row7, row8, row9 };

            Assert.False(Sudoku.IsSudoku(sudokuTable));
        }

        [Fact]
        public void SudokuWorksShouldReturnFalse2()
        {
            int[] row1 = new int[] { 0, 3, 5, 2, 6, 9, 7, 8, 1 }; // changed element at position 0 to 0
            int[] row2 = new int[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 };
            int[] row3 = new int[] { 1, 9, 7, 8, 3, 4, 5, 6, 2 };
            int[] row4 = new int[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 };
            int[] row5 = new int[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 };
            int[] row6 = new int[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 };
            int[] row7 = new int[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 };
            int[] row8 = new int[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 };
            int[] row9 = new int[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 };

            var sudokuTable = new List<int[]> { row1, row2, row3, row4, row5, row6, row7, row8, row9 };

            Assert.False(Sudoku.IsSudoku(sudokuTable));
        }
    }
}