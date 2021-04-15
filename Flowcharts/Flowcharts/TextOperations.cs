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

        public static void CheckLength(string text)
        {
            int limit = 85;

            if (text.Length > limit)
            {
                throw new ArgumentException("Text length cannot exceed {0} characters" + limit);
            }
        }
    }
}