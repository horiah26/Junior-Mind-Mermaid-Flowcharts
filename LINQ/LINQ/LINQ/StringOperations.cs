using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LINQ
{
    public static class StringOperations
    {     
        public static char FirstUniqueChar(string input)
        {
            NullInputException(input);

            char character;

            try
            {
               character = input.GroupBy(character => character).First(groupOfChars => groupOfChars.Count() == 1).Key;
            }
            catch(InvalidOperationException)
            {
                return default;
            }

            return character;
        }

        public static Tuple<int, int> CountVowelsConsonants(string input)
        {
            NullInputException(input);

            const string vowels = "aeiou";
            const string misc = " .,;?!'";

            var vowelsCount = input.ToLower().Where(x => vowels.Contains(x)).Count();
            var consonantsCount = input.ToLower().Where(x => !vowels.Contains(x) && !misc.Contains(x)).Count();

            return new Tuple<int, int>(vowelsCount, consonantsCount);
        }

        public static int StringToInt(string input)
        {
            NullInputException(input);
            return input.Aggregate(0, (total, nextCharacter) => total + nextCharacter);
        }

        public static int MostCommonChar(string input)
        {
            NullInputException(input);

            char character;

            try
            {
                character = input.GroupBy(character => character).OrderBy(group => group.Count()).Last().Key;
            }
            catch (InvalidOperationException)
            {
                return default;
            }

            return character;
        }

        public static IEnumerable<string> SubstringPalindromes(string input)
        {
             return Enumerable.Range(0, input.Length)
                    .SelectMany(a => Enumerable.Range(1, input.Length - a), (origin, size) => (origin, size))
                    .Select(t => input.Substring(t.origin, t.size))
                    .Where(s => s.SequenceEqual(s.Reverse()))
                    .OrderByDescending(c => c.Length);
        }

        private static void NullInputException(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }
        }
    }
}
