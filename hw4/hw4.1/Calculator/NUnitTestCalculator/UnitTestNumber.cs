using Calculator;
using Calculator.Nodes;
using NUnit.Framework;

namespace NUnitTestCalculator
{
    public class UnitTestNumber
    {
        static object[] numberCases =
        {
            new object[] { new Number(1), 1 },
            new object[] { new Number(2), 2 },
            new object[] { new Number(-100), -100 }
        };

        [TestCaseSource(nameof(numberCases))]
        public void TestNumber(Number number, int numberValue)
        {
            Assert.AreEqual(numberValue, number.Calculate());
        }
    }
}