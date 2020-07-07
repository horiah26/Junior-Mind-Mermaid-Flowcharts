using System;
using System.Runtime.InteropServices;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(args[0]);

            var sudoku = new SudokuStructure();

            Console.WriteLine(string.IsNullOrEmpty(sudoku.Match(text).RemainingText()) ? "JSON is Valid!" : "JSON not Valid!");
        }
    }
}
