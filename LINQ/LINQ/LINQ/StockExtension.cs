using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class StockExtension
    {
        public static string ExtendedStockAlert(this Stock stock, string name, int oldQuantity, int newQuantity)
        {
            int[] callbackThresholds = new int[] { 10, 5, 2 };

            string result = "";

            int value;

            try
            {
                value = callbackThresholds.Last(threshold => newQuantity < threshold && oldQuantity >= threshold);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            LowQuantityTest(name, value);

            void LowQuantityTest(string name, int quantity)
            {
                result = "Product '" + name + "' has fewer than " + quantity + " items left";
            }

            return result;
        }
    }
}
