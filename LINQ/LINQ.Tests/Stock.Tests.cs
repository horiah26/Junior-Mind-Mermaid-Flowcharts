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
            static void ExtendedStockAlert(Stock stock, string name, int oldQuantity, int newQuantity)
            {
                int[] callbackThresholds = new int[] { 10, 5, 2 };

                int value = -1;

                try
                {
                    value = callbackThresholds.Last(threshold => newQuantity < threshold && oldQuantity >= threshold);
                }
                catch (InvalidOperationException)
                {
                    stock.previousSubstractionTriggeredAlert = false;
                    return;
                }

                if (value < 0)
                {
                    stock.previousSubstractionTriggeredAlert = false;
                    return;
                }

                stock.previousSubstractionTriggeredAlert = true;

                Console.WriteLine("Product '" + name + "' has fewer than " + value + " items left");
            }

            var stock = new Stock();
            var product1 = new Product("Product 1", 15);
            var action = new Action<Stock, string, int, int>(ExtendedStockAlert);

            stock.AddProduct(product1);
            stock.SetAlert(action);

            stock.Substract(product1, 2);//13
            Assert.False(stock.previousSubstractionTriggeredAlert);

            stock.Substract(product1, 2);//11
            Assert.False(stock.previousSubstractionTriggeredAlert);

            stock.Substract(product1, 2);//9
            Assert.True(stock.previousSubstractionTriggeredAlert);

            stock.Substract(product1, 2);//7
            Assert.False(stock.previousSubstractionTriggeredAlert);

            stock.Substract(product1, 2);//5
            Assert.False(stock.previousSubstractionTriggeredAlert);

            stock.Substract(product1, 2);//3
            Assert.True(stock.previousSubstractionTriggeredAlert);

            stock.Substract(product1, 2);//1
            Assert.True(stock.previousSubstractionTriggeredAlert);

            stock.Substract(product1, 1);//0
            Assert.False(stock.previousSubstractionTriggeredAlert);
        }
    }
}