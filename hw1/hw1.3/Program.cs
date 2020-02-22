using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ArraySort
{
    static int[] BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j + 1] > array[j])
                {
                    int temporary = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temporary;
                }
            }
        }
        return array;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter values of array: ");
        var inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

        inputArray = BubbleSort(inputArray);
        Console.Write("Sorted array: ");
        Console.WriteLine(String.Join(" ", inputArray));
    }
}