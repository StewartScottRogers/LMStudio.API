public record Node<T>
   {
       private readonly T Data { get; }
       private readonly Node<T> Next { get; }
       public Node(T data) : this(data, null) {}
       public Node(T data, Node<T> next) => new(data, next);
   }