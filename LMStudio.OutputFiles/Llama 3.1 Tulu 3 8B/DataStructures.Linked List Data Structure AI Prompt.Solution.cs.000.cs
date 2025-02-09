// ListNode.cs
public record ListNode<T>(T Value, ListNode<T>? Next)
{
    // Properties for easy access and modification.
    public T Item => Value;
    public ListNode<T>? NextNode { get; init; } = null;

    // Method to print list for debugging purposes.
    public override string ToString()
    {
        return Next is null
            ? Value.ToString()
            : $"{Value} -> {Next.ToString()}";
    }
}