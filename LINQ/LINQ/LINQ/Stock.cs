using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class Stock
    {
        public Dictionary<string, Product> products;

        private IStockAlert stockAlert;

        public int this[string key]
        {
            get => products.Single(prod => prod.Key == key).Value.Quantity;
        }

        public Stock(int size = 5)
        {
            products = new Dictionary<string, Product>(size);
        }

        public void AddStockAlert(IStockAlert stockAlert)
        {
            this.stockAlert = stockAlert;
        }

        public void AddProduct(Product product)
        {
            if (products.ContainsKey(product.Name))
            {
                throw new InvalidOperationException("Product already exists. Please use Refill function");
            }

            products.Add(product.Name, product);
        }

        public void Refill(Product product, int quantity)
        {            
            Refill(product.Name, quantity);
        }

        public void Refill(string name, int quantity)
        {
            CheckProductExists(name);

            products[name].Add(quantity);
        }

        public void Substract(Product product, int quantity)
        {
            Substract(product.Name, quantity);
        }

        public void Substract(string name, int quantity)
        {
            CheckProductExists(name);
            CheckIfPossible(name, quantity);

            int oldQuantity = products[name].Quantity;

            products[name].Substract(quantity);

            if (stockAlert != null)
            {
                stockAlert.Alert(name, oldQuantity, products[name].Quantity);
            }
        }

        public void RemoveProduct(Product product)
        {
            CheckProductExists(product.Name);

            products = products.Where(prod => !prod.Equals(product)).ToDictionary(prod => prod.Key, prod => prod.Value);
        }

        public int TotalQuantity()
        {
            return products.Aggregate(0, (total, nextProduct) => total + nextProduct.Value.Quantity);
        }

        private void CheckIfPossible(string Product, int quantity)
        {
            if(products[Product].Quantity - quantity < 0)
            {
                throw new InvalidOperationException("Insufficient stock");
            }
        }

        private void CheckProductExists(string productName)
        {
            if (!products.ContainsKey(productName))
            {
                throw new InvalidOperationException("Product does not exist");
            }
        }
    }
}