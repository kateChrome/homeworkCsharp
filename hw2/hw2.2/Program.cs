using System;

namespace hwTwoDotTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new hashTable();
            hashTable.AddValue("test1");
            hashTable.AddValue("test2");
            hashTable.AddValue("test3");
            hashTable.AddValue("test4");
            hashTable.AddValue("test5");
            hashTable.AddValue("test6");
            hashTable.AddValue("test7");
            hashTable.AddValue("test8");
            hashTable.PrintHashTable();
            hashTable.RemoveValue("test6");
            hashTable.RemoveValue("test1");
            hashTable.RemoveValue("test4");
            hashTable.RemoveValue("asdasdasd");
            Console.WriteLine($"\nis \"test2\" in hashTable? {hashTable.IsInTheHashTable("test2")}");
            Console.WriteLine($"is \"test20\" in hashTable? {hashTable.IsInTheHashTable("test20")}\n");
            hashTable.PrintHashTable();
        }
    }
}
