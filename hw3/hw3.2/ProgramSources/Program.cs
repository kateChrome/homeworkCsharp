using System;

namespace ProgramSources
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable(new HashSHA1());
            hashTable.AddValue("test1");
            hashTable.AddValue("test2");
            hashTable.AddValue("test3");
            hashTable.AddValue("test4");
            hashTable.AddValue("test5");
            hashTable.AddValue("test6");
            hashTable.PrintHashTable();
            hashTable.AddValue("test7");
            hashTable.changeHashFunction(new HashMD5());
            hashTable.AddValue("test8");
            hashTable.AddValue("test9");
            hashTable.AddValue("test10");
            hashTable.AddValue("test11");
            hashTable.AddValue("test12");
            hashTable.AddValue("test13");
            hashTable.AddValue("test14");
            hashTable.AddValue("test15");
            hashTable.AddValue("test16");
            hashTable.AddValue("test17");
            hashTable.AddValue("test18");
            hashTable.PrintHashTable();
            hashTable.AddValue("test19");
            hashTable.AddValue("test20");
            hashTable.AddValue("test21");
            hashTable.AddValue("test22");
            hashTable.AddValue("test23");
            hashTable.AddValue("test24");
            hashTable.AddValue("test25");
            hashTable.AddValue("test26");
            hashTable.AddValue("test27");
            hashTable.AddValue("test28");
            hashTable.AddValue("test29");
            hashTable.PrintHashTable();
            hashTable.RemoveValue("test6");
            hashTable.RemoveValue("test1");
            hashTable.RemoveValue("test4");
            hashTable.RemoveValue("test1337");
            hashTable.RemoveValue("test11");
            hashTable.RemoveValue("test17");
            hashTable.RemoveValue("test18");
            Console.WriteLine($"\nis \"test2\" in hashTable? {hashTable.IsInTheHashTable("test2")}");
            Console.WriteLine($"is \"test20\" in hashTable? {hashTable.IsInTheHashTable("test20")}\n");
            hashTable.PrintHashTable();

            hashTable.changeHashFunction(new HashMD5());
            hashTable.PrintHashTable();
            hashTable.changeHashFunction(new HashSHA1());
            hashTable.PrintHashTable();
            hashTable.changeHashFunction(new HashMD5());
            hashTable.PrintHashTable();
        }
    }
}
