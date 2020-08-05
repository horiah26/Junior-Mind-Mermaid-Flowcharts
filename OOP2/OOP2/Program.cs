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

            foreach (var a in array)
            {
                Console.WriteLine(a);
            }
        }
    }
}
