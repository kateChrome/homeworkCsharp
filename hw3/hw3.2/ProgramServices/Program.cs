using System;

namespace HwThreeDotTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter mode of hash function (0 - MD5, 1 - MD4): ");
            int mode = Convert.ToInt32(Console.ReadLine());
            while (mode != 0 && mode != 1)
            {
                Console.Write("Enter correct number: ");
                mode = Convert.ToInt32(Console.ReadLine());
            }

            IHashFunction hash = null;
            switch (mode)
            {
                case 0:
                    {
                        hash = new HashFunctionMD5();
                        break;
                    }
                case 1:
                    {
                        hash = new HashFunctionMD4();
                        break;
                    }
            }

            var hashTable = new HashTable(hash);
            hashTable.AddValue("test1");
            hashTable.AddValue("test2");
            hashTable.AddValue("test3");
            hashTable.AddValue("test4");
            hashTable.AddValue("test5");
            hashTable.AddValue("test6");
            Console.WriteLine();
            hashTable.PrintHashTable();
            hashTable.AddValue("test7");
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
            Console.WriteLine();
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
            Console.WriteLine();
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
        }
    }
}
