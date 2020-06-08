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

        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

        /// <summary>
        /// Keystroke handling and creating events.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        LeftHandler(this, EventArgs.Empty);
                        break;
                    }
                    case ConsoleKey.RightArrow:
                    {
                        RightHandler(this, EventArgs.Empty);
                        break;
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        UpHandler(this, EventArgs.Empty);
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        DownHandler(this, EventArgs.Empty);
                        break;
                    }
                }
            }
        }
    }
}