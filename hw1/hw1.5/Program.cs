using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of lines: ");
            int numberOflines = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of size of line: ");
            int sizeOfLine = int.Parse(Console.ReadLine());

            int[][] inputArray = new int[sizeOfLine][];
            for (int i = 0; i < numberOflines; i++)
            {
                inputArray[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            Array.Sort(inputArray);

            for (int i = 0; i < numberOflines; i++)
            {
                for (int j = 0; j < sizeOfLine; j++)
                {
                    Console.Write(inputArray[i][j] + " ");
                }
                Console.Write(Environment.NewLine);
            }

        }
    }
}
