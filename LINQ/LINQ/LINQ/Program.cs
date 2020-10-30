using System;
using System.Collections.Generic;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 15);

            int[] threshold = new int[] { 20, 10 ,5 ,2};

            void TestMethod(string name, int quantity)
            {
                Console.WriteLine("Product '{0}' has fewer than {1} items left", name, quantity);
            }

            stock.AddCallback(TestMethod, threshold);

            stock.AddProduct(product1);
            stock.Substract(product1, 6);
        }
    }
}