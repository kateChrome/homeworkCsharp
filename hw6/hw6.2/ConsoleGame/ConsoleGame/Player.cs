using System;

namespace ConsoleGame
{
    /// <summary>
    /// Player class implementation.
    /// </summary>
    public class Player
    {
        public Map GameMap { set; get; }
        public (int first, int second) Position { set; get; }
        public (int first, int second) LastPosition { set; get; }

        public Player(Map map)
        {
            this.GameMap = map;
            this.Position = map.PlayerStartPosition;
            this.LastPosition = map.PlayerStartPosition;
        }

        /// <summary>
        /// Change player position.
        /// </summary>
        public bool TakeOneStep(EventLoop.Direction step)
        {
            var newPosition = Position;
            switch (step)
            {
                case EventLoop.Direction.Up:
                    newPosition.second--;
                    break;
                case EventLoop.Direction.Right:
                    newPosition.first++;
                    break;
                case EventLoop.Direction.Left:
                    newPosition.first--;
                    break;
                case EventLoop.Direction.Down:
                    newPosition.second++;
                    break;
            }

            if (!GameMap.IsCorrectPosition(newPosition))
            {
                return false;
            }

            this.LastPosition = Position;
            this.Position = newPosition;
            return true;

        }
    }
}