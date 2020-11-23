using System.Linq;
using System;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = NumberOperations.PlusMinusMix(4, 2);

            foreach(var v in a)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine();
        }
    }
}