namespace LinkedListLibrary
{
    public class LinkedList
    {
        private readonly Node head;

        public LinkedList()
        {
            head = new Node(0); // Dummy node to simplify edge cases
        }

        public void InsertAtBeginning(int value)
        {
            var newNode = new Node(value);
            newNode.Next = head.Next;
            head.Next = newNode;
        }

        public bool DeleteElement(int valueToDelete)
        {
            var currentNode = head;

            while (currentNode != null && currentNode.Next != null)
            {
                if (currentNode.Next.Value == valueToDelete)
                {
                    currentNode.Next = currentNode.Next.Next;
                    return true; // Element found and deleted
                }
                currentNode = currentNode.Next;
            }
            return false; // Element not found
        }

        public bool SearchElement(int valueToSearch)
        {
            var currentNode = head.Next;

            while (currentNode != null)
            {
                if (currentNode.Value == valueToSearch)
                {
                    return true; // Element found
                }
                currentNode = currentNode.Next;
            }
            return false; // Element not found
        }
    }
}