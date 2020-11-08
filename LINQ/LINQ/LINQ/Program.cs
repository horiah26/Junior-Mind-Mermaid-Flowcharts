using System;
using System.Linq;
namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            static void ExtendedStockAlert(string name, int oldQuantity, int newQuantity, bool actionDone)
            {
                actionDone = false;
                int[] callbackThresholds = new int[] { 10, 5, 2 };

                int value = -1;

                try
                {
                    value = callbackThresholds.Last(threshold => newQuantity < threshold && oldQuantity >= threshold);
                }
                catch (InvalidOperationException)
                {
                    return;
                }

                if (value < 0)
                {
                    return;
                }

                actionDone = true;

                Console.WriteLine("Product '" + name + "' has fewer than " + value + " items left");
            }

            var stock = new Stock();
            var product1 = new Product("Product 1", 15);
            var action = new Action<string, int, int, bool>(ExtendedStockAlert);
            stock.AddProduct(product1);
            stock.SetAlert(action);

            stock.Substract(product1, 13);
        }
    }
}