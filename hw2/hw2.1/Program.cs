using System;

namespace hwTwoDotOne
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Append(10);
            list.Append(11);
            list.Append(13);
            list.Append(100);
            list.Insert(1000, 0);
            list.PrintList();
            list.Insert(12000, 0);
            list.SetDataOfNodeByIndex(100001,2);
            list.PrintList();
        }
    }
}
