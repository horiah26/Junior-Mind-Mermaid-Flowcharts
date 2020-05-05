using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (HasLetters(input))
            {
                return false;
            }

            const string numbers = "0123456789";
            return numbers.IndexOf(input) != -1;
        }

        static bool HasLetters(string input)
        {
            const string forbiddenLetters = "abcdfghijklmnopqrstuvwxyz";

            foreach (char c in input)
            {
                if (forbiddenLetters.IndexOf(c) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        static bool HasNumbers(string input)
        {
            const string forbiddenLetters = "abcdfghijklmnopqrstuvwxyz";

            foreach (char c in input)
            {
                if (forbiddenLetters.IndexOf(c) == -1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
