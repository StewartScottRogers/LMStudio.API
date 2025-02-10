namespace LinkedList.DataStructures
{
    public readonly record LinkedListNode<T> (T Value, LinkedListNode<T>? Next);
}