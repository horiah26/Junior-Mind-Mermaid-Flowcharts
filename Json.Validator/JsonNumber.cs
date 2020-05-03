using System;

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

            if (input[0] == '0' && input.Length != 1)
            {
                return false;
            }

            int number;
            return int.TryParse(input, out number);
        }
    }
}
