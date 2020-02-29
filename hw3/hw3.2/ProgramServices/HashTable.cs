using System;
using System.Security.Cryptography;
using System.Text;

namespace HwThreeDotTwo
{
    class HashTable
    {
        private List[] table;

        private const double maximumFillFactor = 1.2;
        private const int size = 5;
        private int numberOfItems;
        private IHashFunction HashFunction;
        public HashTable(IHashFunction HashFunction)
        {
            table = null; 
            numberOfItems = 0;
            this.HashFunction = HashFunction;
        }

        private void FillFactorChecking()
        {
            if (numberOfItems / table.Length <= maximumFillFactor)
            {
                return;
            }

            var newTable = new List[table.Length * 2];
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
                var temporaryNodes = table[i].returnAllNodes();
                foreach (var item in temporaryNodes)
                {
                    newTable[HashFunction.Hash(item, newTable.Length)].Append(item);
                }
            }
            table = newTable;
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
                table[HashFunction.Hash(data, table.Length)].Append(data);
                numberOfItems++;
                return;
            }
            table[HashFunction.Hash(data, table.Length)].Append(data);
            numberOfItems++;
            FillFactorChecking();
        }

        public bool RemoveValue(string data)
        {
            if (table == null)
            {
                throw new Exception("table does not exist now");
            }
            else if (table[HashFunction.Hash(data, table.Length)].IsOnTheList(data))
            {
                table[HashFunction.Hash(data, table.Length)].DeleteData(data);
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

            return table[HashFunction.Hash(data, table.Length)].IsOnTheList(data);
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].IsEmpty())
                {
                    continue;
                }
                Console.Write($"{HashFunction.Hash(table[i].ReturnHeadValue(), table.Length)}: ");
                table[i].PrintList();
            }
        }
    }
}
