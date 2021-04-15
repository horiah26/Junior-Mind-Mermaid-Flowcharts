using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public static class TextOperations
    {
        public static string[] SplitText(string text)
        {
            return new SplitText(text).GetLines();
        }

        public static void WriteText(double xPosition, double yPosition, string[] lines)
        {
            new WrittenText(xPosition, yPosition, lines).Write();
        }

        public static void TextLengthWithinLimit(string text)
        {
            int limit = 85;

            if (text.Length > limit)
            {
                throw new ArgumentException("Text length cannot exceed {0} characters" + limit);
            }
        }

        public static double CalculateSizeOfText(string[] lines)
        {
            return new TextSizeCalculator(lines).Calculate();
        }

        public static TextSizePair Pair(double value, char letter)
        {
            return new TextSizePair(value, letter);
        }

        public static double CalculateLength(string[] lines)
        {
            return new ShapeLengthCalculator(lines).GetLength();
        }

        public static List<TextSizePair> GetSizeList()
        {
            return new TextSizeList().GetList();
        }
    }
}