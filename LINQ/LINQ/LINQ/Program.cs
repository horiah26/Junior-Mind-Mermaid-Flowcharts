using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        public static void Main()
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 5};
            var a = lista.SkipLast(2);
            var b = lista.TakeLast(2);

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}