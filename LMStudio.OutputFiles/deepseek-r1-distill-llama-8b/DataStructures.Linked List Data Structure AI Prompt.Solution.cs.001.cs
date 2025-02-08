public class LinkedList<T> where T : class
   {
       private readonly Node<T> _head;
       private readonly Node<T> _tail;

       public LinkedList() => ResetHead();

       private void ResetHead()
       {
           _head = new Node<T>(default!, null);
           _tail = _head;
       }

       public bool AddFirst(T data)
       {
           if (ReferenceEquals(data, null))
               throw new ArgumentNullException(nameof(data));

           var newNode = new Node<T>(data, _head);

           if (_head.Next == null)
               _tail = newNode;

           _head = newNode;

           return true;
       }

       public bool Search(T data)
       {
           Node<T> current = _head;
           while (current != null && !Object.Equals(current.Data, data))
           {
               current = current.Next;
           }
           return current != null;
       }

       public bool Delete(Node<T> node)
       {
           if (_head == node)
               _head = node.Next;

           if (node.Previous is Node<T> previousNode)
           {
               previousNode.Next = node.Next;
               if (previousNode.Next == null)
                   _tail = previousNode;
           }

           return true;
       }
   }