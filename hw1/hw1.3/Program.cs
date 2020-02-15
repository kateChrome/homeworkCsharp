using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ArraySort
{
    public static void Main(string[] args)
    {
        int sizeOfArray;
        Console.Write("Enter the number of elements: ");
        sizeOfArray = int.Parse(Console.ReadLine());
        Console.Write("Enter values of array: ");
        var inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        Array.Sort(inputArray);
        Console.Write("Sorted array: ");
        Console.WriteLine(String.Join(" ", inputArray));
    }
}