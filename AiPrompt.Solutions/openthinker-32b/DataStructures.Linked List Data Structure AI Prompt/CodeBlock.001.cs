using System.Collections.Generic;

namespace LinkedListSolution
{
    public class LinkedList<T> : IListOperations<T>
    {
        private readonly Node<T>? _head;

        public bool IsEmpty => _head == null;

        public void InsertAtBeginning(T value)
        {
            var newNode = new Node<T>(value, _head);
            _head = newNode;
        }

        public (bool Found, T? Value) FindElement(T value)
        {
            var currentNode = _head;

            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, value))
                    return (true, currentNode.Value);

                currentNode = currentNode.NextNode;
            }

            return (false, default);
        }

        public bool DeleteElement(T value)
        {
            if (_head == null) 
                return false;

            if (EqualityComparer<T>.Default.Equals(_head.Value, value))
            {
                _head = _head.NextNode;
                return true;
            }

            var currentNode = _head;
            while (currentNode.NextNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.NextNode.Value, value))
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }
    }
}