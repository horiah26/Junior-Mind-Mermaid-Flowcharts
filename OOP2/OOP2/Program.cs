using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {

            var array = new SortedList<char>();
            array.Add('d');
            array.Add('e');
            array.Add('c');
            array.Add('a');
            array.Add('g');

            array.Insert(1, 'b');


            for (int i = 0; i< array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
