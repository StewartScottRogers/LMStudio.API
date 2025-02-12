namespace LinkedListNamespace.Interfaces
{
    public interface INode<T>
    {
        T Data { get; set; }
        INode<T> Next { get; set; }
    }
}