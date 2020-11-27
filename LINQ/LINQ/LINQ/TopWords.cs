using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class TopWords
    {
        public static IEnumerable<string> TopWordsInText(string text)
        {
            return text.Replace(".", "").Replace(",", "").Split(" ").GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key);
        }
    }
}
