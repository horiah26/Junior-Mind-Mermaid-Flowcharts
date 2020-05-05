using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            const string numbers = "0123456789";
            return numbers.IndexOf(input) != -1;
        }
    }
}
