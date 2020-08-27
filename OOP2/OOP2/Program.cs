using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();


            linkedList.Add(3);

            Console.WriteLine(linkedList.sentinel.Next.Next.data);


        }
    }
}