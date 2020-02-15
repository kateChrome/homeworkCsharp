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

            int[,] inputArray = new int[numberOflines, sizeOfLine];
            int[] temporaryArray = new int[sizeOfLine];

            Console.WriteLine("Enter matrix line by line:");
            for (int i = 0; i < numberOflines; i++)
            {
                temporaryArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < sizeOfLine; j++)
                {
                    inputArray[i, j] = temporaryArray[j];
                }
            }

            for (int i = 0; i < sizeOfLine; i++)
            {
                for (int j = 0; j < sizeOfLine - 1; j++)
                {
                    if (inputArray[0, j] < inputArray[0, j + 1])
                    {
                        for (int k = 0; k < numberOflines; k++)
                        {
                            int temporaryVariable = inputArray[k, j];
                            inputArray[k, j] = inputArray[k, j + 1];
                            inputArray[k, j + 1] = temporaryVariable;
                        }
                    }
                }
            }

            Console.WriteLine("Sorted matrix:");
            for (int i = 0; i < numberOflines; i++)
            {
                for (int j = 0; j < sizeOfLine; j++)
                {
                    Console.Write(inputArray[i, j] + " ");
                }
                Console.Write(Environment.NewLine);
            }

        }
    }
}
