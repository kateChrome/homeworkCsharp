using System;
public class Fibonacci
{
    public static void Main(string[] args)
    {
        int firstValue = 1;
        int secondValue = 1;
        int temporaryValue, inputNumber;

        Console.Write("Enter the number of elements: ");
        inputNumber = int.Parse(Console.ReadLine());
        Console.Write("Fibonacci values: " + firstValue + " " + secondValue + " ");
        for (int i = 2; i < inputNumber; i++)
        {
            temporaryValue = firstValue + secondValue;
            Console.Write(temporaryValue + " ");
            firstValue = secondValue;
            secondValue = temporaryValue;
        }
        
        Console.Write(Environment.NewLine);
    }
}