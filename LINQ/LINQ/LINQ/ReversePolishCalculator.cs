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

            CheckWrongCharacters(splitExpression);
            CheckEnoughOperandsAndOperators(splitExpression);

            var operators = new List<string> { "+", "-", "*", "/" };

            IEnumerable<double> seed = new List<double> { };

            return splitExpression.Aggregate(seed, (accumulated, currentElement) => operators.Contains(currentElement) ?
                                                                                  ApplyOperandOnLastTwoAccumulated(accumulated, currentElement) :
                                                                                  AppendToAccumulated(accumulated, currentElement))
                                                                                  .Single();
        }

        static IEnumerable<double> ApplyOperandOnLastTwoAccumulated(IEnumerable<double> accumulated, string operand)
        {
            double first = accumulated.SkipLast(1).TakeLast(1).Single();
            double second = accumulated.Last();

            double operationResult = default;

            switch (operand)
            {
                case "-":
                    operationResult = first - second;
                    break;
                case "*":
                    operationResult = first * second;
                    break;
                case "/":
                    operationResult = first / second;
                    break;
                case "+":
                    operationResult = first + second;
                    break;
            }

            return accumulated.SkipLast(2).Append(operationResult);
        }

        static IEnumerable<double> AppendToAccumulated(IEnumerable<double> accumulated, string number)
        {
            double.TryParse(number, out double numberAsDouble);

            return accumulated.Append(numberAsDouble);
        }

        static void CheckNotNull(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("Expression cannot be null");
            }
        }

        static void CheckWrongCharacters(List<string> splitExpression)
        {
            var operators = new List<string> { "+", "-", "*", "/" };
            var digits = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            if (splitExpression.Any(x => !operators.Concat(digits).Contains(x)))
            {
                throw new InvalidOperationException("Expression can only contain digits and aritmethic operands");
            }
        }

        static void CheckEnoughOperandsAndOperators(List<string> splitExpression)
        {
            if (splitExpression.Count() < 3)
            {
                throw new InvalidOperationException("Expression too short");
            }

            var digits = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            (int operators, int digits) seed = (0, 0);

            var counter = splitExpression.Aggregate(seed, (accumulator, next) => digits.Contains(next) ? (accumulator.operators, accumulator.digits + 1) : (accumulator.operators + 1, accumulator.digits));
            int difference = counter.digits - counter.operators;

            if (difference > 1)
            {
                throw new InvalidOperationException("There are too many numbers in the expression");
            }
            else if (difference < 1)
            {
                throw new InvalidOperationException("There are too many operands in the expression");
            }
        }
    }
}