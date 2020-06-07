using System;

namespace ConsoleGame
{
    /// <summary>
    /// Handles keystrokes and returns the corresponding tuple.
    /// </summary>
    public class EventLoop
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public static Direction GetDirection()
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        return Direction.Up;
                    }
                    case ConsoleKey.RightArrow:
                    {
                        return Direction.Right;
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        return Direction.Left;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        return Direction.Down;
                    }
                }
            }
        }
    }
}