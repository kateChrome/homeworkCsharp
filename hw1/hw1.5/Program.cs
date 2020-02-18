using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1._5
{
    class Program
    {
        static void GetInputMatrix(int[,] inputArray)
        {
            int[] temporaryArray = new int[inputArray.GetLength(1)];
            for (int i = 0; i < inputArray.GetLength(0); i++)
            {
                temporaryArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < inputArray.GetLength(1); j++)
                {
                    inputArray[i, j] = temporaryArray[j];
                }
            }
        }

        static void SortMatrixByFirstElement(int[,] inputArray)
        {
            for (int i = 0; i < inputArray.GetLength(1); i++)
            {
                for (int j = 0; j < inputArray.GetLength(1) - i - 1; j++)
                {
                    if (inputArray[0, j] < inputArray[0, j + 1])
                    {
                        for (int k = 0; k < inputArray.GetLength(0); k++)
                        {
                            int temporaryVariable = inputArray[k, j];
                            inputArray[k, j] = inputArray[k, j + 1];
                            inputArray[k, j + 1] = temporaryVariable;
                        }
                    }
                }
            }
        }

        static void PrintMatrix(int[,] inputArray)
        {
            for (int i = 0; i < inputArray.GetLength(0); i++)
            {
                for (int j = 0; j < inputArray.GetLength(1); j++)
                {
                    Console.Write($"{inputArray[i, j]} ");
                }
                Console.Write(Environment.NewLine);
            }
        }
        
        static void Main(string[] args)
        {
            Console.Write("Enter the number of lines: ");
            int numberOflines = int.Parse(Console.ReadLine());
            Console.Write("Enter the size of line: ");
            int sizeOfLine = int.Parse(Console.ReadLine());
            int[,] inputArray = new int[numberOflines, sizeOfLine];

            Console.WriteLine("Enter matrix line by line:");
            GetInputMatrix(inputArray);
            SortMatrixByFirstElement(inputArray);

            Console.WriteLine("Sorted matrix:");
            PrintMatrix(inputArray);
        }
    }
}
