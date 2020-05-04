using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            const int lastCharPosition = 2;

            if (!CheckIfControl(input))
            {
                return false;
            }

            if (input == "\"")
            {
                return false;
            }

            if (input[input.Length - lastCharPosition] == '\\' && char.IsLetterOrDigit(input[input.Length - lastCharPosition - 1]))
            {
                return false;
            }

            if (!CheckForEscapes(input))
            {
                return false;
            }

            if (!CheckPositionOfSlash(input))
            {
                return false;
            }

            return input[0] == '"' && input[input.Length - 1] == '"';
        }

        static bool NotCharacterEscape(char letter)
        {
            const string allowedEscape = "0abtrvfnu";
            return allowedEscape.IndexOf(letter) == -1;
        }

        static bool CheckForEscapes(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && NotCharacterEscape(input[i + 1]) && char.IsLetter(input[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckIfControl(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsControl(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckPositionOfSlash(string input)
        {
            const int LastPositionOfSlash = 7;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u' && input.Length - i < LastPositionOfSlash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
