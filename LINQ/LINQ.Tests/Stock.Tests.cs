using System;
using Xunit;
using System.Linq;

namespace LINQ.Tests
{
    public class StockTests
    {
        [Fact]
        public void CanCreateStock()
        {
            var stock = new Stock();
            Assert.NotNull(stock);
        }

        [Fact]
        public void CanAddProduct()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);

            stock.AddProduct(product1);

            Assert.Equal(5, stock["Product 1"]);
        }

        [Fact]
        public void CanAddSeveralProducts()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);
            var product2 = new Product("product 2", 1);

            stock.AddProduct(product1);
            stock.AddProduct(product2);

            Assert.Equal(5, stock["Product 1"]);
            Assert.Equal(1, stock["product 2"]);
        }

        [Fact]
        public void CanSubstractProducts()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);

            stock.AddProduct(product1);
            stock.Substract(product1, 3);

            Assert.Equal(2, stock["Product 1"]);
        }

        [Fact]
        public void CanSubstractProductsWithName()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);

            stock.AddProduct(product1);
            stock.Substract("Product 1", 3);

            Assert.Equal(2, stock["Product 1"]);
        }

        [Fact]
        public void QuantityCannotBeNegative()
        {
            var stock = new Stock(); 
            var product1 = new Product("Product 1", 5);

            stock.AddProduct(product1);

            Assert.Throws<InvalidOperationException>(() => stock.Substract("Product 1", 6));
        }

        [Fact]
        public void CanRefillProduct()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);

            stock.AddProduct(product1);
            stock.Refill(product1, 3);

            Assert.Equal(8, stock["Product 1"]);
        }

        [Fact]
        public void CanRefillProductWithName()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);

            stock.AddProduct(product1);
            stock.Refill("Product 1", 3);

            Assert.Equal(8, stock["Product 1"]);
        }

        [Fact]
        public void TotalWorks()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);
            var product2 = new Product("Product 2", 7);

            stock.AddProduct(product1);
            stock.AddProduct(product2);

            Assert.Equal(12, stock.TotalQuantity());
        }

        [Fact]
        public void CanRemoveProduct()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);

            stock.AddProduct(product1);
            stock.RemoveProduct(product1);

            Assert.Throws<InvalidOperationException>(() => stock["product 1"]);
        }

        [Fact]
        public void ReturnsExceptionWhenUsingNegativeQuantity()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 5);

            stock.AddProduct(product1);

            Assert.Throws<InvalidOperationException>(() => stock.Refill("Product 1", -3));
            Assert.Throws<InvalidOperationException>(() => stock.Substract("Product 1", -3));
            Assert.Throws<InvalidOperationException>(() => new Product("Product 2", -5));
        }

        [Fact]
        public void ThrowsCallbackWhenProductQuantityBelowThreshold()
        {
            var stock = new Stock();
            var product1 = new Product("Product 1", 15);

            stock.AddProduct(product1);

            string resultOfAction = stock.ExtendedStockAlert("Product 1", 13, 9);

            Assert.Equal("Product 'Product 1' has fewer than 10 items left", resultOfAction);
        }

        [Fact]
        public void CallbackWorks()
        {
            static void ExtendedStockAlert(string name, int oldQuantity, int newQuantity,  bool actionDone)
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

                if(value < 0)
                {
                    return;
                }

                actionDone = true;

                Console.WriteLine("Product '" + name + "' has fewer than " + value + " items left");            
            }

            var stock = new Stock();
            var product1 = new Product("Product 1", 15);

            stock.SetAlert(new Action<string, int, int, bool>(ExtendedStockAlert));

            stock.AddProduct(product1); // mai trebuie sa fac un bool cumva sa returneze true; caut C# test Action; fac un bool in stock pe care il activeaza actionu
        }
    }
}