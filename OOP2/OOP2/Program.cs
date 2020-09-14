using System;

namespace OOP2
{
    class Program
    {
        static void Main()
        {
            var dictionary = new Dictionary<int, string>(5);

            dictionary.Add(0, "a");

            dictionary.Add(10, "b");
            dictionary.Add(15, "b");

            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine(dictionary.elements[dictionary.buckets[0]].Next);
        }
    }
}