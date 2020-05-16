using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String input = File.ReadAllText(@"S:\github\hw6\hw6.2\ConsoleGame\ConsoleGame\maps\map1");

            bool[,] mapFromFile = new bool[40,40];
            var i = 0;
            foreach (var row in input.Split('\n'))
            {
                var j = 0;
                foreach (var col in row)
                {
                    mapFromFile[i, j] = col == '#';
                    j++;
                }
                i++;
            }

            var game = new Game(mapFromFile, (10, 10));
            game.Start();
        }
    }
}
