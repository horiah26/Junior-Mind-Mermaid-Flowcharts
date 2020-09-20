using System;
using System.Collections.Generic;

namespace OOP2
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(3, "a");
            dictionary.Add(4, "b");
            dictionary.Add(5, "c");

            var array = new KeyValuePair<int, string>[3];
            Console.WriteLine("array count" + array.Length);
            Console.WriteLine("dictionary count" + dictionary.Count);

            dictionary.CopyTo(array, 0);

            Console.WriteLine("array count 2" + array.Length);
            foreach (var v in array)
            {
                Console.WriteLine(v);
            }

        }
    }
}
