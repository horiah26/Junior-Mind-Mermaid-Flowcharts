using System;
using System.Linq;
namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string ex = "abc";
            Console.WriteLine(StringOperations.FirstUniqueChar(ex));
            Console.WriteLine(StringOperations.StringToInt(ex));

        }
    }
}