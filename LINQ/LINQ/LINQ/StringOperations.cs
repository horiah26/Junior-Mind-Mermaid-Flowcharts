using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ
{
    public static class StringOperations
    {
        public static char FirstUniqueChar(string input)
        {
            EnusureIsNotNull(input, nameof(input));

            char character;

            character = input.GroupBy(character => character).FirstOrDefault(groupOfChars => groupOfChars.Count() == 1).Key;

            return character;
        }

        public static (int, int) CountVowelsConsonants(string input)
        {
            EnusureIsNotNull(input, nameof(input));

            const string vowels = "aeiou";

            var trimmedString = Regex.Replace(input, @"[^0-9a-zA-Z]+", "");

            (int vowels, int consonants) accumulator = (0, 0);

            return trimmedString.ToLower().Aggregate(accumulator, (accumulator, character)
                   => vowels.Contains(character) ? (accumulator.vowels + 1, accumulator.consonants) : (accumulator.vowels, accumulator.consonants + 1));
        }

        public static int StringToInt(this string input)
        {
            EnusureIsNotNull(input, nameof(input));

            int sign = 1;

            if (input.FirstOrDefault().Equals('-'))
            {
                sign = -1;
                input = input.Substring(1);
            }
            else if (input.FirstOrDefault().Equals('+'))
            {
                input = input.Substring(1);
            }

            return input.Aggregate(0, (total, next) => total * 10 + next - '0') * sign;
        }

        public static int MostCommonChar(string input)
        {
            EnusureIsNotNull(input, nameof(input));

            return input.GroupBy(character => character).OrderBy(group => group.Count()).Last().Key;
        }

        public static IEnumerable<string> SubstringPalindromes(string input)
        {
            return Enumerable.Range(0, input.Length)
                   .SelectMany(a => Enumerable.Range(1, input.Length - a), (origin, size) => (origin, size))
                   .Select(t => input.Substring(t.origin, t.size))
                   .Where(s => s.SequenceEqual(s.Reverse()))
                   .OrderByDescending(c => c.Length);
        }

        public static IEnumerable<string> SubstringsSum(string input)
        {
            return Enumerable.Range(0, input.Length)
                   .SelectMany(a => Enumerable.Range(1, input.Length - a), (origin, size) => (origin, size))
                   .Select(t => input.Substring(t.origin, t.size))
                   .Where(s => s.SequenceEqual(s.Reverse()))
                   .OrderByDescending(c => c.Length);
        }

        private static void EnusureIsNotNull(string input, string name)
        {
            if (input == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}