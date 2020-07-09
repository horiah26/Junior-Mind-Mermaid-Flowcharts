using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new IntArray();
            Console.WriteLine(array.Count());
            Console.WriteLine(array.Element(1));
            Console.WriteLine(array.Element(2));
            Console.WriteLine(array.Element(3));
        }
    }
}
