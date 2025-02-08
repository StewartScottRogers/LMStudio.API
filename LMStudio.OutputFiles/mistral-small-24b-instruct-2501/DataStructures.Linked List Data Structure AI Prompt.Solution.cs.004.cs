using System.IO;

namespace LinkedListDataStructure.Classes
{
    public class SinglyLinkedList<T>
    {
        private ILinkedListNode<T> Head { get; set; }

        public SinglyLinkedList()
        {
            this.Head = null;
        }

        public void InsertAtBeginning(T data)
        {
            var newNode = new LinkedListNode<T>(data);
            newNode.Next = this.Head;
            this.Head = newNode;
        }

        public bool DeleteElement(T data)
        {
            if (this.Head == null) return false;

            if (this.Head.Data.Equals(data))
            {
                this.Head = this.Head.Next;
                return true;
            }

            var current = this.Head;
            while (current.Next != null && !current.Next.Data.Equals(data))
            {
                current = current.Next;
            }

            if (current.Next == null) return false;

            current.Next = current.Next.Next;
            return true;
        }

        public bool SearchElement(T data)
        {
            var current = this.Head;
            while (current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }

        public void PrintList()
        {
            var current = this.Head;
            using (var writer = new StreamWriter(Console.OpenStandardOutput()))
            {
                while (current != null)
                {
                    writer.WriteLine(current.Data.ToString());
                    current = current.Next as LinkedListNode<T>;
                }
            }
        }
    }
}