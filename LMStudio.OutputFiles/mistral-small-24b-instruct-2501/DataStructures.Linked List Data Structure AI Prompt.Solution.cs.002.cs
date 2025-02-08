namespace LinkedListDataStructure.Records
{
    public record NodeRecord<T>(T Data, ILinkedListNode<T> Next);
}