using System;
public class Fibonacci
{
    static void ComputeFibonacciNumbersAndPrint(int inputNumber)
    {
        int firstValue = 1;
        int secondValue = 1;

        Console.Write($"Fibonacci values: {firstValue} {secondValue} ");
        for (int i = 2; i < inputNumber; i++)
        {
            int temporaryValue = firstValue + secondValue;
            Console.Write($"{temporaryValue} ");
            firstValue = secondValue;
            secondValue = temporaryValue;
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter the number of elements: ");
        int inputNumber = int.Parse(Console.ReadLine());
        ComputeFibonacciNumbersAndPrint(inputNumber);
        Console.Write(Environment.NewLine);
    }
}