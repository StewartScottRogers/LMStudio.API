using System;

namespace LinkedListDataStructure
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private readonly Node<T> head;
        public LinkedList()
        {
            this.head = null;
        }

        public void InsertAtBeginning(T value)
        {
            var newNode = new Node<T>(value) { Next = this.head };
            this.head = newNode;
        }

        public bool Search(T value)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                if (Equals(currentNode.Value, value))
                    return true;

                currentNode = currentNode.Next;
            }
            return false;
        }

        public bool Delete(T value)
        {
            if (this.head == null)
                return false;

            if (Equals(this.head.Value, value))
            {
                this.head = this.head.Next;
                return true;
            }

            var currentNode = this.head;
            while (currentNode.Next != null)
            {
                if (Equals(currentNode.Next.Value, value))
                {
                    currentNode.Next = currentNode.Next.Next;
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public string Display()
        {
            var currentNode = this.head;
            var result = new System.Text.StringBuilder();

            while (currentNode != null)
            {
                result.Append(currentNode.Value).Append(" -> ");
                currentNode = currentNode.Next;
            }

            result.Append("null");
            return result.ToString();
        }
    }
}