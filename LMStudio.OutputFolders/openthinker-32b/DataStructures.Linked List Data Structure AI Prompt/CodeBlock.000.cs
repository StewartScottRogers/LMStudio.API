public record NodeRecord
{
    public int Data { get; set; }
    public NodeRecord NextNode { get; set; }
}