using System;

namespace ConsoleGame
{
    /// <summary>
    /// Game class implementation.
    /// </summary>
    public class Game
    {
        private readonly Map _map;
        private readonly Player _player;

        public Game(bool[,] map, (int first, int second) position)
        {
            this._map = new Map(map, position);
            this._player = new Player(this._map);
        }

        /// <summary>
        /// Starts this game.
        /// Keyboard input processing and map redrawing.
        /// </summary>
        public void Start()
        {
            Rendering();
            while (true)
            {
                _player.TakeOneStep(EventLoop.GetDirection());
                PlayerRendering();
            }
        }

        /// <summary>
        /// Renderings this game.
        /// </summary>
        private void Rendering()
        {
            MapRendering();
            PlayerRendering();
        }

        /// <summary>
        /// Renderings this map.
        /// </summary>
        private void MapRendering()
        {
            Console.SetCursorPosition(0, 0);
            for (var i = 0; i < _map.GameMap.GetLength(0); i++)
            {
                for (var j = 0; j < _map.GameMap.GetLength(1); j++)
                {
                    if (_map.GameMap[i, j])
                    {
                        Console.Write("#");
                        continue;
                    }

                    Console.Write(" ");
                }

                Console.Write(Environment.NewLine);
            }
        }

        /// <summary>
        /// Renderings this player.
        /// </summary>
        private void PlayerRendering()
        {
            Console.SetCursorPosition(_player.LastPosition.first, _player.LastPosition.second);
            Console.Write(" ");
            Console.SetCursorPosition(_player.Position.first, _player.Position.second);
            Console.Write("@");
            Console.SetCursorPosition(0, 0);
        }
    }
}