using System;

namespace ConsoleGame
{
    public class Game
    {
        private readonly Map _map;
        private readonly Player _player;

        public Game(bool[,] map, (int first, int second) position)
        {
            this._map = new Map(map, position);
            this._player = new Player(this._map);
        }

        public void Start()
        {
            Rendering();
            while (true)
            {
                _player.TakeOneStep(GetDirection());
                Rendering();
            }
        }

        private (bool, bool) GetDirection()
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        return (false, false);
                    }
                    case ConsoleKey.RightArrow:
                    {
                        return (false, true);
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        return (true, false);
                    }
                    case ConsoleKey.DownArrow:
                    {
                        return (true, true);
                    }
                }
            }
        }

        private void Rendering()
        {
            MapRendering();
            PlayerRendering();
        }

        private void MapRendering()
        {
            Console.SetCursorPosition(0,0);
            for (var i = 0; i < _map.GameMap.GetLength(0); i++)
            {
                for (var j = 0; j < _map.GameMap.GetLength(1); j++)
                {
                    if (_map.GameMap[i, j])
                    {
                        Console.Write("#");
                    }
                    Console.Write(" ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        private void PlayerRendering()
        {
            Console.SetCursorPosition(_player.Position.first, _player.Position.second);
            Console.Write("@");
        }
    }
}