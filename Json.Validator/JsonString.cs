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

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsControl(input[i]))
                {
                    return false;
                }
            }

            if (input == "\"")
            {
                return false;
            }

            return input[0] == '"' && input[input.Length - 1] == '"';
        }
    }
}
