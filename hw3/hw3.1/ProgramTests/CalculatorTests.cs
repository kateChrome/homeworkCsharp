using System;
using NUnit.Framework;

namespace Program.Services.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator(new ArrayStack());
        }

        static object[] CalculatingCorrectExpressionsCases =
        {
                new object[] { "1 2 + 3 - 4 + 5 - 6 +", 5 },
                new object[] { "1 2 * 3 12 * 4 / - 789 -", -796 },
                new object[] { "7 7 + 7 7 / 7 * -", 7 },
        };

        [TestCaseSource(nameof(CalculatingCorrectExpressionsCases))]
        public void CalculateCalculateWithCorrectExpressionTest(string expression, int result)
        {
            Assert.AreEqual(result, calculator.Calculate(expression));
        }

        static object[] CalculatingUncorrectExpressionCases =
        {
            new object[] { "12 - 12 - - 122 + 10293 -", "incorrect expression" },
            new object[] { "223 12 - 222 + 122 * * 122", "incorrect expression" },
            new object[] { "222 1111 + 222 - 23334 * 122 / 1212 - -", "incorrect expression" },
            new object[] { "1 2 + 3 - 4 + 5 - 6 + +", "incorrect expression" },
            new object[] { "1 2 + 3 - 4 + 5 - 6 + + =", "incorrect expression" },
            new object[] { "abc", "unknown character" },
            new object[] { "1 2 * 3 12a * 4 / - 789 -", "unknown character" }
        };

        [TestCaseSource(nameof(CalculatingUncorrectExpressionCases))]
        public void CalculateCalculateWithUncorrectExpressionTest(string expression, string currentException)
        {
            try
            {
                calculator.Calculate(expression);
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, currentException);
            }
        }

    }
}