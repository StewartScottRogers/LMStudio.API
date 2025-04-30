namespace LinkedListSolution
{
    public readonly record struct Node<T>
    {
        public T Value { get; init; }
        public Node<T>? NextNode { get; init; }

        public Node(T value, Node<T>? nextNode = null)
        {
            Value = value;
            NextNode = nextNode;
        }
    }
}