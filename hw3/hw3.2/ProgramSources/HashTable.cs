using System;
using System.Security.Cryptography;
using System.Text;

namespace ProgramSources
{
    /// <summary>
    /// Class with implementation hash table structure.
    /// </summary>
    public class HashTable
    {
        private List[] table;
        private const double maximumFillFactor = 1.2;
        private const int size = 5;
        private int numberOfItems;

        /// <summary>
        /// get number of items in hash table
        /// </summary>
        public int NumberOfItems { get { return numberOfItems; } }

        private IHash hash;

        /// <summary>
        /// set hash table and its hash function
        /// </summary>
        /// <param name="hash"></param>
        public HashTable(IHash hash) { table = null; numberOfItems = 0; this.hash = hash; }

        /// <summary>
        /// resize hash table
        /// </summary>
        /// <param name="size">new hash table size</param>
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
            FillFactorCheck();
        }

        /// <summary>
        /// check fill factor and fix size, if current fill factore more then constant fill factor
        /// </summary>
        private void FillFactorCheck()
        {
            if (numberOfItems / table.Length <= maximumFillFactor)
            {
                return;
            }

            ChangeHashTableSize(table.Length * 2);
        }

        /// <summary>
        /// add data to hash table
        /// </summary>
        /// <param name="data">data to be add</param>
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
                FillFactorCheck();
                return;
            }
            table[hash.Hash(data, table.Length)].Append(data);
            numberOfItems++;
            FillFactorCheck();
        }

        /// <summary>
        /// remove data from hash table
        /// </summary>
        /// <param name="data">data to be remove</param>
        /// <returns></returns>
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

        /// <summary>
        /// check data for existence in table
        /// </summary>
        /// <param name="data">data to be check for existence</param>
        /// <returns></returns>
        public bool IsInTheHashTable(string data)
        {
            if (table == null)
            {
                throw new Exception("table does not exist now");
            }

            return table[hash.Hash(data, table.Length)].IsOnTheList(data);
        }

        /// <summary>
        /// print hash table bucket by bucket
        /// </summary>
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

        /// <summary>
        /// change hash function in hash table and recalculate all data places
        /// </summary>
        /// <param name="hash">new hash function</param>
        public void ChangeHashFunction(IHash hash)
        {
            this.hash = hash;

            ChangeHashTableSize(size);
        }

        /// <summary>
        /// calculate hash of input data and return this
        /// </summary>
        /// <param name="data">input data</param>
        /// <returns>hash value of input data</returns>
        public int GetHash(string data)
        {
            return hash.Hash(data, HashTable.size);
        }
    }
}
