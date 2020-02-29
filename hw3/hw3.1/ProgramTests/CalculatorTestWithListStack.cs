using System;
using NUnit.Framework;

namespace HwThreeDotOne.Tests
{
    public class CalculatorTestWithListStack
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator(new ListStack());
        }

        [Test]
        public void CalculateWhithCorrectExpression1Test()
        {
            string inputExpression = "1 2 + 3 7 * - 12 4 / + 3 9 * -";
            Assert.AreEqual(calculator.Calculate(inputExpression), -42);
        }

        [Test]
        public void CalculateWhithCorrectExpression2Test()
        {
            string inputExpression = "100000 11110 - 121212 4 / - 1232 3 * -";
            Assert.AreEqual(calculator.Calculate(inputExpression), 54891);
        }

        [Test]
        public void CalculateWhithUncorrectExpressionWithExcessSigns1Test()
        {
            try
            {
                string inputExpression = "1 2 + 3 7 * - 12 4 / + 3 9 * - -";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }

        [Test]
        public void CalculateWhithUncorrectExpressionWithUnknowCharactersTest()
        {
            try
            {
                string inputExpression = "1 2 + 3 7 * - 12 '); DROP TABLE passwords;-- 4 / + 3 9 * -";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "unknown character");
            }
        }

        [Test]
        public void CalculateWhithUncorrectExpressionWithExcessValuesTest()
        {
            try
            {
                string inputExpression = "1 2 33 1337 + 3 7 * - 12 4 / + 3 9 * - -";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }

        [Test]
        public void CalculateWhithUncorrectExpressionWithExcessSigns2Test()
        {
            try
            {
                string inputExpression = "1 2 + 3 7 * - + - + 12 4 / + 3 9 * - -";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }

        [Test]
        public void CalculateWhithEmptyExpressionTest()
        {
            try
            {
                string inputExpression = "";
                calculator.Calculate(inputExpression);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }

    }
}