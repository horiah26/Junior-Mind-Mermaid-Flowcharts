using JSON;
using System;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(("\"\\\"a\\\" b\""));
            Console.WriteLine((@"\""a\"" b"));
            Console.WriteLine(@"a \\ b");
            Console.WriteLine("a \\\\ b");
            Console.WriteLine("a \\/ b");
            Console.WriteLine("\"a \\/ b\"");
            Console.WriteLine(@"a \b b");
            Console.WriteLine();
            Console.WriteLine("\"a\n b \rc\"");
            Console.WriteLine(@"a\");
            Console.WriteLine("\"a\\\"");
            Console.WriteLine(@"a\u");
            Console.WriteLine("\"a\\u\"");
        }
    }
}
