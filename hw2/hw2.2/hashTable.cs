using System;
using System.Security.Cryptography;
using System.Text;

namespace hwTwoDotTwo
{
    class hashTable
    {
        private List[] table;

        public hashTable() { table = null; }

        public string hash(string data)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString().Substring(0,1);
        }
        
        public void AddValue(string data)
        {
            if (table == null)
            {
                table = new List[1];
                table[0] = new List();
                table[0].Hash = hash(data);
                table[0].Append(data);
                return;
            }
            string currentHash = hash(data);
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].Hash == currentHash)
                {
                    if (table[i].IsOnTheList(data))
                    {
                        return;
                    }
                    else
                    {
                        table[i].Append(data);
                        return;
                    }
                }
            }
            Array.Resize(ref table, table.Length + 1);
            table[table.Length - 1] = new List();
            table[table.Length - 1].Hash = currentHash;
            table[table.Length - 1].Append(data);

        }

        public bool RemoveValue(string data)
        {
            if (table == null)
            {
                throw new Exception("table == null");
            }

            string currentHash = hash(data);
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].Hash == currentHash)
                {
                    table[i].DeleteData(data);
                    if (table[i].isEmpty())
                    {
                        for (int j = i; j < table.Length - 1; j++)
                        {
                            table[j] = table[j + 1];
                        }
                        Array.Resize(ref table, table.Length - 1);
                    }
                    return true;
                }
            }

            return false;
        }

        public bool IsInTheHashTable(string data)
        {
            if (table == null)
            {
                throw new Exception("table == null");
            }

            string currentHash = hash(data);
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].Hash == currentHash)
                {
                    if (table[i].IsOnTheList(data))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.Write($"{table[i].Hash}: ");
                table[i].PrintList();
            }
        }
    }
}
