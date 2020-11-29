using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class NumberOperations
    {
        public static IEnumerable<int[]> SegmentsSmallerThan(int[] input, int max)
        {
            return Enumerable.Range(0, input.Length)
                .SelectMany(a => Enumerable.Range(1, input.Length - a), (origin, size) => (origin, size))
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

        public static IEnumerable<(int, int, int)> PythagorasTrios(int[] numbers)
        {
            IEnumerable<(int, int, int)> seed = new List<(int, int, int)> { };

            return Enumerable.Range(0, numbers.Length)
                  .SelectMany(a => Enumerable.Range(0, numbers.Length), (a, b) => (a, b))
                  .SelectMany(pair => Enumerable.Range(0, numbers.Length), (pair, c) => (pair.a, pair.b, c))
                  .Select(trio => (numbers[trio.a], numbers[trio.b], numbers[trio.c]))
                  .Where(trio => Math.Pow(trio.Item3, 2) == Math.Pow(trio.Item2, 2) + Math.Pow(trio.Item1, 2))
                  .Aggregate(seed, (total, next) => total.Contains((next.Item2, next.Item1, next.Item3)) ? total : total.Append(next));
        }
    }
}