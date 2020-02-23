using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    public enum Directions
    {
        Up,
        Down,
        Left,
        Right
    }

    class Program
    {
        private static void PrintMatrixByRule(int[,] array)
        {
            bool isFinish = false;
            int step = 0;
            int sizeOfCurrentLine = 0;
            Directions currentDirection = Directions.Up;
            int counter = 0;
            int firstIndex = array.GetLength(0) / 2;
            int secondIndex = array.GetLength(0) / 2;

            Console.Write(array[firstIndex, secondIndex] + " ");

            while (counter < array.GetLength(0) * array.GetLength(0))
            {
                if (isFinish)
                {
                    break;
                }
                if (step % 2 == 0)
                {
                    sizeOfCurrentLine++;
                }
                if (currentDirection == Directions.Up)
                {
                    for (int t = 0; t < sizeOfCurrentLine; t++)
                    {
                        firstIndex--;
                        Console.Write(array[firstIndex, secondIndex] + " ");
                        counter++;
                        if (counter == array.GetLength(0) * array.GetLength(0) - 1)
                        {
                            isFinish = true;
                            break;
                        }
                    }
                    currentDirection = Directions.Left;
                    step++;
                    continue;
                }
                if (currentDirection == Directions.Left)
                {
                    for (int t = 0; t < sizeOfCurrentLine; t++)
                    {
                        secondIndex--;
                        Console.Write(array[firstIndex, secondIndex] + " ");
                        counter++;
                        if (counter == array.GetLength(0) * array.GetLength(0) - 1)
                        {
                            isFinish = true;
                            break;
                        }
                    }
                    currentDirection = Directions.Down;
                    step++;
                    continue;
                }
                if (currentDirection == Directions.Down)
                {
                    for (int t = 0; t < sizeOfCurrentLine; t++)
                    {
                        firstIndex++;
                        Console.Write(array[firstIndex, secondIndex] + " ");
                        counter++;
                        if (counter == array.GetLength(0) * array.GetLength(0) - 1)
                        {
                            isFinish = true;
                            break;
                        }
                    }
                    currentDirection = Directions.Right;
                    step++;
                    continue;
                }
                if (currentDirection == Directions.Right)
                {
                    for (int t = 0; t < sizeOfCurrentLine; t++)
                    {
                        secondIndex++;
                        Console.Write(array[firstIndex, secondIndex] + " ");
                        counter++;
                        if (counter == array.GetLength(0) * array.GetLength(0) - 1)
                        {
                            isFinish = true;
                            break;
                        }
                    }
                    currentDirection = Directions.Up;
                    step++;
                    continue;
                }
            }
        }

        static void Main(string[] args)
        {
            int size;
            do
            {
                Console.Write("Enter size of array: ");
                size = Convert.ToInt32(Console.ReadLine());
            } while (size % 2 != 1);

            Console.WriteLine("Enter array line by line: ");
            string[] lineArray;
            int[,] array = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                lineArray = Console.ReadLine().Split(' ');

                for (int j = 0; j < size; j++)
                {
                    array[i, j] = Convert.ToInt32(lineArray[j]);
                }
            }

            PrintMatrixByRule(array);
        }
    }
}