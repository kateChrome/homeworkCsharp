using Calculator;
using NUnit.Framework;

namespace NUnitTestCalculator
{
    public class UnitTestSolver
    {
        static object[] calculateCases =
        {
            new object[] { new Solver("(* (+ 1 1) 2)"), 4 },
            new object[] { new Solver("(/ (* (+ 1 1) 2) (* (+ 1 1) 2))"), 1 },
            new object[] { new Solver("(- (/ (* (+ 1 1) 2) (* (+ 1 1) 2)) (/ (* (+ 1 1) 2) (* (+ 1 1) 2)))"), 0 }
        };

        [TestCaseSource(nameof(calculateCases))]
        public void Test1(Solver expression, int result)
        {
            Assert.AreEqual(result, expression.Calculate());
        }
    }
}