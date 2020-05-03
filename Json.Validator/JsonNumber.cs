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

            if (MultipleDots(input))
            {
                return false;
            }

            if (input[0] == '0' && input.Length != 1 && input.IndexOf(".") != 1)
            {
                return false;
            }

            if (input[input.Length - 1] == '.')
            {
                return false;
            }

            double number;
            return double.TryParse(input, out number);
        }

        static bool MultipleDots(string input)
        {
            const int maxDots = 2;
            return input.Length - input.Replace(".", "").Length >= maxDots;
        }
    }
}
