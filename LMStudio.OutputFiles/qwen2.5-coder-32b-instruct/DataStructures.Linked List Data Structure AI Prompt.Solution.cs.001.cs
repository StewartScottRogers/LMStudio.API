using System.Collections.Generic;

namespace LinkedListSolution
{
    public class LinkedList<T>
    {
        private Node<T>? head;

        public void InsertAtBeginning(T value)
        {
            var newNode = new Node<T>(value);
            newNode.Next = head;
            head = newNode;
        }

        public bool Search(T value)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                    return true;
                currentNode = currentNode.Next;
            }
            return false;
        }

        public bool Delete(T value)
        {
            if (head == null) 
                return false;

            if (head.Value.Equals(value))
            {
                head = head.Next;
                return true;
            }

            var currentNode = head;
            while (currentNode.Next != null && !currentNode.Next.Value.Equals(value))
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next == null)
                return false;

            currentNode.Next = currentNode.Next.Next;
            return true;
        }
    }
}