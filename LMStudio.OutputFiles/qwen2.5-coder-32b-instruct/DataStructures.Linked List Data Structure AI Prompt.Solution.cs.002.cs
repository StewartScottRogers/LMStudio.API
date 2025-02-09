using System;

namespace LinkedListSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            
            list.InsertAtBeginning(1);
            list.InsertAtBeginning(2);
            list.InsertAtBeginning(3);

            Console.WriteLine("Search for 2: " + list.Search(2));
            Console.WriteLine("Delete 2: " + list.Delete(2));
            Console.WriteLine("Search for 2 after delete: " + list.Search(2));
        }
    }
}