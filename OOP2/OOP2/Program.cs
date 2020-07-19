using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new SortedIntArray();

            array.Insert(0, 3);
            array.Insert(1, 6);
            array.Insert(2, 7);

            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
