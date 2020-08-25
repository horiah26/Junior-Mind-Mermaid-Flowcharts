using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            var listArray = new List<int>();

            listArray.Add(3);
            listArray.Add(10);
            listArray.Add(24);
            listArray.Add(35);
            listArray.Add(15);

            var readList = new ReadOnlyList<int>(listArray);
            readList.Insert(1,1);

           foreach (var v in readList)
            {
                Console.WriteLine(v);
            }

        }
    }
}