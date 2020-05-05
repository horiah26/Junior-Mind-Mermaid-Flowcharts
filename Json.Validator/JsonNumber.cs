using System;
using System.Reflection.Metadata.Ecma335;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input[input.Length - 1] == '.')
            {
                return false;
            }

            if (input[0] == '0' && input.Length > 1 && input.IndexOf('.') == -1)
            {
                return false;
            }

            if (HasMultipleDotsOrExponents(input))
            {
                return false;
            }

            return !HasLetters(input);
        }

        static bool HasLetters(string input)
        {
            const string forbiddenLetters = "abcdfghijklmnopqrstuvwxyz";

            input = input.ToLower();

            foreach (char c in input)
            {
                if (forbiddenLetters.IndexOf(c) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        static bool HasMultipleDotsOrExponents(string input)
        {
            return input.Length - input.Replace(".", "").Length > 1 || input.Length - input.Replace("e", "").Length > 1;
        }
    }
}