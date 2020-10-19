using System;

namespace LINQ
{
    class Program
    {

        static void Main(string[] args)
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 10);
            var product2 = new Product("Product 2", 7);

            stock.AddProduct(product1);
            stock.AddProduct(product2);
            stock.Substract("Product 1", 1);
            stock.Substract("Product 2", 1);
            Console.WriteLine(stock.TotalQuantity());

        }
    }
}