using System;

namespace MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertAtBeginning(10);
            list.InsertAtBeginning(20);
            Console.WriteLine(list.Search(10)); // True
            list.Delete(10);
            Console.WriteLine(list.Search(10)); // False
        }
    }
}