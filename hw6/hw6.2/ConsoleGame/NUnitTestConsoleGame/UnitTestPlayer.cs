using ConsoleGame;
using NUnit.Framework;

namespace NUnitTestConsoleGame
{
    class UnitTestPlayer
    {
        private Player _player;

        [SetUp]
        public void SetUp()
        {
            var mapBools = new bool[,]
            {
                {true, true, true, true, true, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, false, false, false, false, true},
                {true, true, true, true, true, true}
            };

            _player = new Player(new Map(mapBools, (1, 1)));
        }

        [Test]
        public void TestAreTheLastAndCurrentPositionsEqualToEachOther()
        {
            Assert.True(_player.LastPosition == _player.Position);
        }

        [Test]
        public void TestLastPositionAfterMove()
        {
            var lastPosition = _player.LastPosition;
            _player.TakeOneStep((true, true));
            Assert.AreEqual(lastPosition, _player.LastPosition);
        }

        [Test]
        public void TestCorrectMove()
        {
            var position = _player.Position;
            position.first++;
            _player.TakeOneStep((false, true));
            Assert.AreEqual(position, _player.Position);
        }

        [Test]
        public void TestIncorrectMove()
        {
            var position = _player.Position;
            _player.TakeOneStep((false, false));
            Assert.AreEqual(position, _player.Position);
        }
    }
}
