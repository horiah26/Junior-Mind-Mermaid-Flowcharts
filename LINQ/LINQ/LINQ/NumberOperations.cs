using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public static class NumberOperations
    {
        public static IEnumerable<int[]> SegmentsSmallerThan(int[] input, int max)
        {
            return Enumerable.Range(0, input.Length)
                .SelectMany(a => Enumerable.Range(0, input.Length + 1 - a), (origin, size) => (origin, size))
                .Where(s => s.size > 0)
                .Select(s => input.Skip(s.origin).Take(s.size).ToArray())
                .Where(s => s.Sum() <= max);
        }

        public static IEnumerable<string> PlusMinusMix(int n, int k)
        {
            IEnumerable<string> seed = new[] { "" };

            return Enumerable.Range(1, n)
                             .Aggregate(seed, (total, x) => total
                             .SelectMany(result => new[] { result + "+" + x + " ", result + "-" + x + " " }))
                             .Where(plusMinusRow => plusMinusRow.PlusMinusStringToInt() == k)
                             .Select(row => row.Trim());
        }

        private static int PlusMinusStringToInt(this string input)
        {
            return input.Split(' ').Aggregate(0, (total, next) => total + next.StringToInt());
        }
    }
}
