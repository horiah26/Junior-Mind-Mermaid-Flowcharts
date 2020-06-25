using JSON;
using System;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Console.WriteLine("done");
            Console.WriteLine(a.Match("1,2").Success());

            Console.WriteLine(a.Match("1,2").RemainingText());

        }
    }
}
