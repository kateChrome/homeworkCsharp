using System;

namespace ConsoleGame
{
    public class Map
    {
        public bool[,] GameMap { set; get; }
        public (int first, int second) PlayerStartPosition;

        public Map(bool[,] map, (int first, int second) position)
        {
            if (map.GetLength(0) < position.first || map.GetLength(1) < position.second)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            if (map[position.first, position.second])
            {
                throw new ArgumentException("Player cannot start from specified starting position.");
            }

            this.GameMap = map;
            this.PlayerStartPosition = position;
        }

        public bool IsCorrectPosition((int first, int second) playerPosition)
        {
            if (GameMap.GetLength(0) <= playerPosition.first || GameMap.GetLength(1) <= playerPosition.second)
            {
                return false;
            }
            else if (playerPosition.first < 0 || playerPosition.second < 0)
            {
                return false;
            }
            else if (GameMap[playerPosition.second, playerPosition.first])
            {
                return false;
            }

            return true;
        }
    }
}