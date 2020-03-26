using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace src
{
    public class Tests
    {
        static object[] MapCases =
        {
                new object[] { new List<int>() { -86, 65, 42, 30, 54, -56, -81, 18, -39, 50, 51, -46, -31, -67 }, new Func<int, int>(x => x * 1337), new List<int>() { -114982, 86905, 56154, 40110, 72198, -74872, -108297, 24066, -52143, 66850, 68187, -61502, -41447, -89579 } },
                new object[] { new List<int>() { 28, 93, 59, 8, -87, 52, -100, -97, 53, -29, -46, 60, 66, -95, 54 }, new Func<int, int>(x => (int)Math.Pow(x, 2)), new List<int>() { 784, 8649, 3481, 64, 7569, 2704, 10000, 9409, 2809, 841, 2116, 3600, 4356, 9025, 2916 } },
                new object[] { new List<int>() { -87, 78, -30, 56, 49, 43, 53, 55, -33, -63, 84, 18, 31, 64, 76, 9, -26, 19 }, new Func<int, int>(x => x - 12 * x), new List<int>() { 957, -858, 330, -616, -539, -473, -583, -605, 363, 693, -924, -198, -341, -704, -836, -99, 286, -209 } },
                new object[] { new List<int>() { -62, 30, 100, 7, 62, 9, -28, -17, 22, 90, -40, 42, -79, 33 }, new Func<int, int>(x => 7), new List<int>() { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 } },
                new object[] { new List<int>() { -53, -70, -25, 38, -39, 79, 23, 56, -30, -71, -24 }, new Func<int, int>(x => x^1010101), new List<int>() { -1010050, -1010161, -1010094, 1010067, -1010068, 1010170, 1010082, 1010061, -1010089, -1010164, -1010083 } }
        };

        [TestCaseSource(nameof(MapCases))]
        public void MapTest(List<int> inputList, Func<int, int> function, List<int> outputList)
        {
            Assert.IsTrue(Functions.Map(inputList, function).SequenceEqual(outputList));
        }

        static object[] FilterCases =
{
                new object[] { new List<int>() { -42, -63, 23, 96, 30, -89, -51, -40, -18, -27, -70, 31, -59, -10, 84, 84, -82, -37, 17, 65 }, new Func<int, bool>(x => x == -42), new List<int>() { -42 } },
                new object[] { new List<int>() { -63, 65, 85, -11, 64, -27, -87, 3, -39, 5, -77, -72, -28, 57, 5, -47, 65, 92, -71 }, new Func<int, bool>(x => x > 10), new List<int>() { 65, 85, 64, 57, 65, 92 } },
                new object[] { new List<int>() { -36, -78, 46, 95, -19, -49, -70, 90, 29, -19, -1, 49, -24, -91, 23, -43, 44, 71, 17 }, new Func<int, bool>(x => Convert.ToInt32(x ^ 10101) > 10), new List<int>() { 46, 95, 90, 29, 49, 23, 44, 71, 17 } },
                new object[] { new List<int>() { 74, -21, -84, 32, 97, -61, -22, -51, -1, 97, 13, 5, -78, 66, 69, -19, 72, -71 }, new Func<int, bool>(x => Convert.ToInt32(x * 123 ^ 456 % 789) > 123), new List<int>() { 74, 32, 97, 97, 13, 5, 66, 69, 72 } },
                new object[] { new List<int>() { 18, 65, 18, 64, 68, 94, 25, 19, 16, 92, 38, 30 }, new Func<int, bool>(x => BigInteger.ModPow(x, x, 10) < 5), new List<int>() { 18, 18, 38, 30 } }
        };

        [TestCaseSource(nameof(FilterCases))]
        public void FilterTest(List<int> inputList, Func<int, bool> function, List<int> outputList)
        {
            Assert.IsTrue(Functions.Filter(inputList, function).SequenceEqual(outputList));
        }

        static object[] FoldCases =
        {
                new object[] { new List<int>() { 29, 47, 81, 61, 75, 58, 41, 31, 59, 61, 49, 86, 37, 59, 13, 26, 20, 11 }, 0, new Func<int, int, int>((accumulator, item) => item + accumulator), 844},
                new object[] { new List<int>() { -67, -76, -40, -35, -21, 10, -82, -39, -75, 21, -16, 16, -68, -8 }, 0, new Func<int, int, int>((accumulator, item) => item - accumulator), 258},
                new object[] { new List<int>() { -97, -52, -36, -99, 37, 42, -1, 50, -52, -86, 39 }, 0, new Func<int, int, int>((accumulator, item) => item ^ accumulator), -111},
                new object[] { new List<int>() { 75, 77, 49, 46, 12, 57, 83, 13, 79 }, 3, new Func<int, int, int>((accumulator, item) => item % accumulator + item), 80},
                new object[] { new List<int>() { 67, 23, 50, 75, 63, 37, 16, 13 }, 3, new Func<int, int, int>((accumulator, item) => item << (accumulator % 2) + item), 106496}
        };

        [TestCaseSource(nameof(FoldCases))]
        public void MapTest(List<int> inputList, int accumulator, Func<int, int, int> function, int accumulatorResult)
        {
            Assert.IsTrue(Functions.Fold(inputList, accumulator, function) == accumulatorResult);
        }
    }
}