using System;

namespace OOP2
{
    class Program
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();

            
            Console.WriteLine(linkedList.sentinel.data);
            linkedList.Add(1);
            Console.WriteLine(linkedList.sentinel.Next.data);
 
           
            linkedList.Add(2);
            Console.WriteLine(linkedList.sentinel.Next.Next.data);
        }
    }
}