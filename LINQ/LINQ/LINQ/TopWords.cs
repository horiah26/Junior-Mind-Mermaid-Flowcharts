using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class TopWords
    {
        public static IEnumerable<string> TopWordsInText(string text)
        {
            char[] splitChars = new char[] { '.', ',', ' ' };
            return text.Split(splitChars, StringSplitOptions.RemoveEmptyEntries).GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key);
        }
    }
}
