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

        private static void NullInputException(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }
        }
    }
}
