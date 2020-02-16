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
        static void Main(string[] args)
        {
            int size = 1;
            do
            {
                Console.Write("Enter size of array: ");
                size = Convert.ToInt32(Console.ReadLine());
            } while (size % 2 != 1);

            Console.WriteLine("Enter array line by line: ");
            string[] line_array;
            int[,] array = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                line_array = Console.ReadLine().Split(' ');

                for (int j = 0; j < size; j++)
                {
                    array[i, j] = Convert.ToInt32(line_array[j]);
                }
            }

            bool isFinish = false;
            int step = 0;
            int sizeOfCurrentLine = 0;
            Directions currentDirection = Directions.Up;
            int k = 0;
            int firstIndex = size / 2;
            int secondIndex = size / 2;
            Console.Write(array[firstIndex, secondIndex] + " ");
            while (k < size * size)
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
                        k++;
                        if (k == size * size - 1) { isFinish = true; break; }
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
                        k++;
                        if (k == size * size - 1)
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
                        k++;
                        if (k == size * size - 1)
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
                        k++;
                        if (k == size * size - 1)
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
    }
}