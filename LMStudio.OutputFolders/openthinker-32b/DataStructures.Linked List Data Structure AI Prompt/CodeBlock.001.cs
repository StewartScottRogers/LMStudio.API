public class LinkedList
{
    private NodeRecord head;

    public void InsertAtBeginning(int data)
    {
        var newHead = new NodeRecord { Data = data };
        newHead.NextNode = head;
        head = newHead;
    }

    public bool Search(int target)
    {
        NodeRecord current = head;
        while (current != null)
        {
            if (current.Data == target)
                return true;
            current = current.NextNode;
        }
        return false;
    }

    public bool Delete(int dataToDelete)
    {
        // Handle empty list
        if (head == null)
            return false;

        // Check if head needs to be deleted
        if (head.Data == dataToDelete)
        {
            head = head.NextNode;
            return true;
        }

        NodeRecord previous = head;
        while (previous != null && previous.NextNode != null)
        {
            if (previous.NextNode.Data == dataToDelete)
            {
                previous.NextNode = previous.NextNode.NextNode;
                return true;
            }
            previous = previous.NextNode;
        }

        return false;
    }
}