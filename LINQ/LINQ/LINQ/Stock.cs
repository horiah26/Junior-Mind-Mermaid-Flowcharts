using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class Stock
    {
        public Dictionary<string, Product> products;

        public int this[string key]
        {
            get => products.Single(prod => prod.Key == key).Value.Quantity;
        }

        public Stock(int size = 5)
        {
            products = new Dictionary<string, Product>(size);
        }

        public void AddProduct(Product product)
        {
            if (products.ContainsKey(product.Name))
            {
                throw new InvalidOperationException("Product already exists. Please use Refill function");
            }

            if(product.Quantity < 0)
            {
                throw new InvalidOperationException("Quantity cannot be negative");
            }

            products.Add(product.Name, product);
        }

        public void Refill(Product product, int quantity)
        {            
            Refill(product.Name, quantity);
        }

        public void Refill(string name, int quantity)
        {
            products[name].Add(quantity);
        }

        public void Substract(string name, int quantity)
        {
            CheckIfPossible(name, quantity);

            products[name].Substract(quantity);

            LowStockAlert(name, products[name].Quantity);
        }

        public void Substract(Product product, int quantity)
        {
            Substract(product.Name, quantity);
        }

        public void RemoveProduct(Product product)
        {
            products = products.Where(prod => !prod.Equals(product)).ToDictionary(prod => prod.Key, prod => prod.Value);
        }

        public int TotalQuantity()
        {
            return products.Aggregate(0, (total, nextProduct) => total + nextProduct.Value.Quantity);
        }

        private void LowStockAlert(string name, int quantity)
        {
            int[] callbackThresholds = { 10, 5, 2};

            try
            {
                Action<int> Callback = nr => Console.WriteLine("There are now fewer than {0} items of the product {1} in the stock.", callbackThresholds.Last(x => x > quantity), name);
                Callback(quantity);
            }
            catch (InvalidOperationException)
            {
                return;
            }
        }

        private void CheckIfPossible(string Product, int quantity)
        {
            if(products[Product].Quantity - quantity < 0)
            {
                throw new InvalidOperationException("Insufficient stock");
            }
        }
    }
}