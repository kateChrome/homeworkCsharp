using System;
using System.IO;

namespace ConsoleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pathToMap = "map0";
            if (args.Length == 1)
            {
                pathToMap = args[0];
            }
            while (!File.Exists(pathToMap))
            {
                Console.WriteLine("Enter path to map file: ");
                pathToMap = Console.ReadLine();
            }
            

            var input = File.ReadAllText(pathToMap);

            var mapFromFile = new bool[40, 40];
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
            
            var eventLoop = new EventLoop();
            var game = new Game(mapFromFile, (10, 10));

            eventLoop.DownHandler += game.OnDown;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.LeftHandler += game.OnLeft;

            game.Rendering();
            eventLoop.Run();
        }
    }
}
