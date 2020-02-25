using System;
using System.Security.Cryptography;
using System.Text;

namespace hwTwoDotTwo
{
    class hashTable
    {
        private List[] table;

        private const double maximumFillFactor = 1.2;
        private const int size = 5;
        private int numberOfItems;
        public hashTable() { table = null; numberOfItems = 0; }

        private int hash(string data, int size)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return Convert.ToInt32(hash.ToString().Substring(0, 5), 16) % size;
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
                    newTable[hash(item, newTable.Length)].Append(item);
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
                table[hash(data, table.Length)].Append(data);
                numberOfItems++;
                return;
            }
            table[hash(data, table.Length)].Append(data);
            numberOfItems++;
            FillFactorChecking();
        }

        public bool RemoveValue(string data)
        {
            if (table == null)
            {
                throw new Exception("table does not exist now");
            }
            else if (table[hash(data, table.Length)].IsOnTheList(data))
            {
                table[hash(data, table.Length)].DeleteData(data);
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

            return table[hash(data, table.Length)].IsOnTheList(data);
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].IsEmpty())
                {
                    continue;
                }
                Console.Write($"{hash(table[i].ReturnHeadValue(), table.Length)}: ");
                table[i].PrintList();
            }
        }
    }
}
