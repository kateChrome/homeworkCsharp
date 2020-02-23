using System;

namespace hw2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Head = new Node(111);
            list.append(10);
            list.append(11);
            list.append(13);
            list.append(100);
            list.insert(1000, 2);
            list.printList();
            list.setDataOfNodeByIndex(100001,2);
            list.printList();
        }
    }
}
