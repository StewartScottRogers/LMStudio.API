namespace LinkedListProject
{
    public class Node
    {
        private readonly int Value;
        private Node Next;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

        public int GetValue() => Value;

        public void SetNext(Node next) => Next = next;

        public Node GetNext() => Next;
    }
}