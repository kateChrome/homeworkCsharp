using ConsoleGame;
using NUnit.Framework;

namespace NUnitTestConsoleGame
{
    public class UnitTestMap
    {
        private static readonly object[] Maps =
        {
            new bool[,]
            {
                {false, false, false},
                {false, false, false},
                {false, false, false},
                {false, false, false}
            },
            new bool[,]
            {
                {true, true, true, true, true, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, true, true, true, true, true}
            }
        };

        [Test]
        public void TestIsCorrectPositionMap0()
        {
            var map = new Map((bool[,]) Maps[0], (0, 0));
            Assert.True(map.IsCorrectPosition((2, 2)));
        }

        [Test]
        public void TestIsCorrectPositionMap1()
        {
            var map = new Map((bool[,])Maps[1], (1, 1));
            Assert.False(map.IsCorrectPosition((0, 2)));
        }

        [Test]
        public void TestIsCorrectPositionBigPositionMap0()
        {
            var map = new Map((bool[,])Maps[0], (0, 0));
            Assert.False(map.IsCorrectPosition((100, 100)));
        }

        [Test]
        public void TestIsCorrectPositionBigPositionMap1()
        {
            var map = new Map((bool[,])Maps[1], (1, 1));
            Assert.False(map.IsCorrectPosition((100, 100)));
        }

        [Test]
        public void TestIsCorrectPositionNegativePositionMap0()
        {
            var map = new Map((bool[,])Maps[0], (0, 0));
            Assert.False(map.IsCorrectPosition((-1, 2)));
        }

        [Test]
        public void TestIsCorrectPositionNegativePositionMap1()
        {
            var map = new Map((bool[,])Maps[1], (1, 1));
            Assert.False(map.IsCorrectPosition((0, -10)));
        }
    }
}