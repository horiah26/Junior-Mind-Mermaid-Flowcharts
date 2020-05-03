using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return input[0] == '"' && input[input.Length - 1] == '"';
        }
    }
}
