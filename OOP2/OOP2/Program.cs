using System;
using System.Collections.Generic;

namespace OOP2
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(1, "b"));
            dictionary.Add(new KeyValuePair<int, string>(2, "c"));
            dictionary.Add(new KeyValuePair<int, string>(3, "d"));

            dictionary.Clear();

            dictionary.Add(1, "b");

            dictionary.Add(2, "c");
        }
    }
}
