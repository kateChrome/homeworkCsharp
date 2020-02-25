using System;

namespace HwTwoDotOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            list.Insert(10, 0);
            list.Insert(11, 1);
            list.Insert(13, 2);
            list.Insert(100, 3);
            list.Insert(1000, 0);
            list.PrintList();
            list.Insert(12000, 0);
            list.SetDataOfNodeByIndex(100001,2);
            list.PrintList();
        }
    }
}
