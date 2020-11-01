using System;

namespace LINQ
{
    public class Product
    {
        public string Name { get; }
        public int Quantity { get; private set; }

        public Product(string name, int quantity)
        {
            CheckIfPositive(quantity);

            Name = name;
            Quantity = quantity;
        }

        public void Add(int amount)
        {
            CheckIfPositive(amount);
            Quantity += amount;
        }

        public void Substract(int amount)
        {
            CheckIfPositive(amount);
            Quantity -= amount;
        }

        private void CheckIfPositive(int amount)
        {
            if(amount < 0)
            {
                throw new InvalidOperationException("Cannot operate with negative numbers");
            }
        }
    }
}
