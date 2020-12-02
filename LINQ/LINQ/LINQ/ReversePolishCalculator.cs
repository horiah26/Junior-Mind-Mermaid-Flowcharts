using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class ReversePolishCalculator
    {
        public static double Calculate(string expression)
        {
            CheckNotNull(expression);

            var splitExpression = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            IEnumerable<double> seed = new List<double> { };

            return splitExpression.Aggregate(seed, (accumulated, currentElement) => double.TryParse(currentElement, out double valueAsDouble) ?
                                                                                    accumulated.Append(valueAsDouble) :
                                                                                    accumulated.SkipLast(2).Append(ApplyOperand(accumulated.TakeLast(2), currentElement)))
                                                                                    .Single();
        }

        static double ApplyOperand(IEnumerable<double> accumulated, string operand)
        {
            if (accumulated.Count() >= 2)
            {
                double first = accumulated.First();
                double second = accumulated.Last();

                switch (operand)
                {
                    case "-":
                        return first - second;
                    case "*":
                        return first * second;
                    case "/":
                        return first / second;
                    case "+":
                        return first + second;
                }
            }

            throw new InvalidOperationException("Input expression is invalid");
        }

        static void CheckNotNull(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("Expression cannot be null");
            }
        }
    }
}