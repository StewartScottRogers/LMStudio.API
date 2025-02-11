public class LinkedList
{
    private Node Head { get; set; }

    // Search Method
    public bool Search(int value)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Data == value)
                return true;
            current = current.Next;
        }
        return false;
    }

    // Insert Method
    public void Insert(int value)
    {
        var newNode = new Node { Data = value, Next = Head };
        Head = newNode;
    }

    // Delete Method
    public bool Delete(int value)
    {
        if (Head == null) return false;
        if (Head.Data == value)
        {
            Head = Head.Next;
            return true;
        }
        var current = Head;
        while (current.Next != null)
        {
            if (current.Next.Data == value)
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        }
        return false;
    }
}