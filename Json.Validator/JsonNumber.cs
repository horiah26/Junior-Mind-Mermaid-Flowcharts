using System;
using System.Reflection.Metadata.Ecma335;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !HasLetters(input);
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
    }
}
