using Calculator.Nodes;
using Calculator.Nodes.Operators;
using NUnit.Framework;

namespace NUnitTestCalculator
{
    public class UnitTestOperator
    {
        static object[] operatorCases =
        {
            new object[] { new Addition(new Number(1), new Number(1)), 1 + 1},
            new object[] { new Addition(new Number(1), new Number(-1)), 1 + -1},
            new object[] { new Addition(new Number(100), new Number(-1000)), 100 + -1000},

            new object[] { new Subtraction(new Number(1), new Number(1)), 1 - 1},
            new object[] { new Subtraction(new Number(1), new Number(-1)), 1 - -1},
            new object[] { new Subtraction(new Number(100), new Number(-1000)), 100 - -1000},

            new object[] { new Multiplication(new Number(1), new Number(1)), 1 * 1},
            new object[] { new Multiplication(new Number(1), new Number(-1)), 1 * (-1)},
            new object[] { new Multiplication(new Number(100), new Number(-1000)), 100 * (-1000)},

            new object[] { new Division(new Number(1), new Number(1)), 1.0 / 1},
            new object[] { new Division(new Number(1), new Number(-1)), 1.0 / (-1)},
            new object[] { new Division(new Number(100), new Number(-1000)), 100.0 / (-1000)}
        };

        [TestCaseSource(nameof(operatorCases))]
        public void Test1(Operator currentOperator, double result)
        {
            Assert.AreEqual(result, currentOperator.Calculate());
        }
    }
}