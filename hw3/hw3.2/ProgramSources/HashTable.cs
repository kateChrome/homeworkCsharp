using System;
using System.Security.Cryptography;
using System.Text;

namespace ProgramSources
{
    public class HashTable
    {
        private List[] table;
        private const double maximumFillFactor = 1.2;
        private const int size = 5;
        private int numberOfItems;

        public int NumberOfItems { get {return numberOfItems;} }

        private IHash hash;

        public HashTable(IHash hash) { table = null; numberOfItems = 0; this.hash = hash; }

        private void ChangeHashTableSize(int size)
        {

            var newTable = new List[size];
            for (int i = 0; i < newTable.Length; i++)
            {
                newTable[i] = new List();
            }

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].IsEmpty())
                {
                    continue;
                }
                var temporaryNodes = table[i].ReturnAllNodes();
                foreach (var item in temporaryNodes)
                {
                    newTable[hash.Hash(item, newTable.Length)].Append(item);
                }
            }
            table = newTable;
            FillFactorChecking();
        }

        private void FillFactorChecking()
        {
            if (numberOfItems / table.Length <= maximumFillFactor)
            {
                return;
            }

            ChangeHashTableSize(table.Length * 2);
        }

        public void AddValue(string data)
        {
            if (table == null)
            {
                table = new List[size];
                for (int i = 0; i < table.Length; i++)
                {
                    table[i] = new List();
                }
                table[hash.Hash(data, table.Length)].Append(data);
                numberOfItems++;
                FillFactorChecking();
                return;
            }
            table[hash.Hash(data, table.Length)].Append(data);
            numberOfItems++;
            FillFactorChecking();
        }

        public bool RemoveValue(string data)
        {
            if (table == null)
            {
                throw new Exception("table does not exist now");
            }
            else if (table[hash.Hash(data, table.Length)].IsOnTheList(data))
            {
                table[hash.Hash(data, table.Length)].DeleteData(data);
                numberOfItems--;
                return true;
            }

            return false;
        }

        public bool IsInTheHashTable(string data)
        {
            if (table == null)
            {
                throw new Exception("table does not exist now");
            }

            return table[hash.Hash(data, table.Length)].IsOnTheList(data);
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].IsEmpty())
                {
                    continue;
                }
                Console.Write($"{hash.Hash(table[i].ReturnHeadValue(), table.Length)}: ");
                table[i].PrintList();
            }
            Console.WriteLine();
        }

        public void ChangeHashFunction(IHash hash)
        {
            this.hash = hash;
            var newTable = new List[size];

            ChangeHashTableSize(size);
        }

        public int GetHash(string data)
        {
            return hash.Hash(data, HashTable.size);
        }
    }
}
