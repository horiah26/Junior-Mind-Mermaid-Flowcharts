using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new ObjectArray();

            array.Add(3);
            array.Add(6);
            array.Add(7);

            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }

            foreach (var a in array)
            {
                Console.WriteLine(a);
            }
        }
    }
}
