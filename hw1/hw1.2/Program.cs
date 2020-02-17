using System;
public class Fibonacci
{
    static void computingFibonacciNumbersAndPrint(int inputNumber)
    {
        int firstValue = 1;
        int secondValue = 1;
        int temporaryValue;

        Console.Write("Fibonacci values: " + firstValue + " " + secondValue + " ");
        for (int i = 2; i < inputNumber; i++)
        {
            temporaryValue = firstValue + secondValue;
            Console.Write(temporaryValue + " ");
            firstValue = secondValue;
            secondValue = temporaryValue;
        }
    }
    public static void Main(string[] args)
    {
        int inputNumber;

        Console.Write("Enter the number of elements: ");
        inputNumber = int.Parse(Console.ReadLine());
        computingFibonacciNumbersAndPrint(inputNumber);
        Console.Write(Environment.NewLine);
    }
}