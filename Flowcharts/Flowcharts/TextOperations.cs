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
    }
}