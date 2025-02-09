namespace LinkedListSolution
{
    public record Node<T>
    {
        public T Value { get; init; }
        public Node<T>? Next { get; init; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
}