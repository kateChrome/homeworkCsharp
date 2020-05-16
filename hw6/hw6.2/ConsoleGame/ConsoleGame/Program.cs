using System;

namespace ConsoleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var array2D = new bool[,] { { false, false, false }, { false, false, false }, { false, false, false }, { false, false, false } };
            var game = new Game(array2D, (1, 1));
            game.Start();
        }
    }
}
