// LinkedList.cs
using System;

namespace LinkedListDataStructure
{
    public class LinkedList
    {
        private LinkedListNode headNode;

        public LinkedList()
        {
            this.headNode = null;
        }

        public void InsertAtBeginning(object data)
        {
            // Create a new node with the given data.
            LinkedListNode newNode = new LinkedListNode(data);

            // Make the new node point to the current head.
            newNode.NextNode = this.headNode;

            // Update the head to be the new node.
            this.headNode = newNode;
        }

        public void DeleteElement(object data)
        {
            // If the list is empty, there's nothing to delete.
            if (this.headNode == null)
            {
                return;
            }

            // If the element to be deleted is at the head.
            if (this.headNode.Data.Equals(data))
            {
                this.headNode = this.headNode.NextNode;
                return;
            }

            // Traverse the list to find the element to delete.
            LinkedListNode currentNode = this.headNode;
            while (currentNode.NextNode != null && !currentNode.NextNode.Data.Equals(data))
            {
                currentNode = currentNode.NextNode;
            }

            // If the element is found, remove it from the list.
            if (currentNode.NextNode != null)
            {
                currentNode.NextNode = currentNode.NextNode.NextNode;
            }
        }

        public bool SearchElement(object data)
        {
            LinkedListNode currentNode = this.headNode;

            // Traverse the list and check if the element exists.
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    return true; // Element found.
                }
                currentNode = currentNode.NextNode;
            }

            return false; // Element not found.
        }

        public void DisplayList()
        {
            LinkedListNode currentNode = this.headNode;
            while (currentNode != null)
            {
                Console.Write(currentNode.Data + " ");
                currentNode = currentNode.NextNode;
            }
            Console.WriteLine();
        }
    }
}