using System;

namespace OOP2
{
    class Program
    {
        static void Main()
        {
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);

            foreach (var v in sentence)
            {
                Console.WriteLine(v);
            }

        }
    }
}