using System;
using Xunit;

namespace LINQ.Tests
{
    public class ReversePolishCalculatorTests
    {
        [Fact]
        public void ReversePolishCalculatorWorks()
        {
            string operation = "3 4 - 5 *";

            var expcted = ReversePolishCalculator.Calculate(operation);
            double actual = -5;

            Assert.Equal(actual, expcted);
        }

        [Fact]
        public void ReversePolishCalculatorWorks2()
        {
            string operation = "3 4 5 * -";

            var expcted = ReversePolishCalculator.Calculate(operation);
            double actual = -17;

            Assert.Equal(actual, expcted);
        }

        [Fact]
        public void ThrowsExceptionWhenIncorrectCharacters()
        {
            string operation = "a 3 4 5 * -";

            Assert.Throws<InvalidOperationException>(() => ReversePolishCalculator.Calculate(operation));
        }

        [Fact]
        public void ThrowsExceptionWhenTooManyOperators()
        {
            string operation = "2 3 4 5 * -";

            Assert.Throws<InvalidOperationException>(() => ReversePolishCalculator.Calculate(operation));
        }

        [Fact]
        public void ThrowsExceptionWhenTooManyOperands()
        {
            string operation = "3 4 5 * - +";

            Assert.Throws<InvalidOperationException>(() => ReversePolishCalculator.Calculate(operation));
        }
    }
}