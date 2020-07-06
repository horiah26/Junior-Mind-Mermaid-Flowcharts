using System;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(args[0]);

            var value = new Value();

            Console.WriteLine(string.IsNullOrEmpty(value.Match(text).RemainingText()) ? "JSON is Valid!" : "JSON not Valid!");
        }
    }
}
