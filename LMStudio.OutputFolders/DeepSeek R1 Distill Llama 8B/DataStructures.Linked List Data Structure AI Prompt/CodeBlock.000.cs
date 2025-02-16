using System;
using System.Collections.Generic;

namespace LinkedListSolution
{
    public interface IListOperations
    {
        bool Add(Node node);
        bool Remove(Node node);
        bool Contains(object value);
        Node? SearchNode(object value);
    }

    public class Node
    {
        public object Data { get; set; }
        public Node? Next { get; set; }
    }

    public class LinkedList : IListOperations
    {
        private Node head;
        private Node tail;

        public bool Add(Node node)
        {
            if (node == null)
                return false;

            if (head == null)
                head = node;
            else
            {
                node.Next = head;
                head = node;
            }

            return true;
        }

        public bool Remove(Node node)
        {
            if (node == null || !Contains(node.Data))
                return false;

            Node previousNode = FindPrevious(node);

            if (previousNode is not null)
                previousNode.Next = node.Next;
            else
                head = node.Next;

            if (node.Next is not null)
                node = node.Next;
            else
                tail = previousNode;

            return true;
        }

        public bool Contains(object value)
        {
            Node current = head;
            while (current != null && current.Data != value)
                current = current.Next;

            return current != null;
        }

        public Node? SearchNode(object value)
        {
            Node current = head;
            while (current != null && current.Data != value)
                current = current.Next;

            return current;
        }

        private Node FindPrevious(Node node)
        {
            Node current = head;
            while (current != null && current.Data != node.Data)
                current = current.Next;

            if (current is not null)
                return current;
            else
                return null;
        }
    }

    public class Tests
    {
        public static void TestAddAtStart()
        {
            var list = new LinkedList();
            var node = new Node { Data = "First Node" };
            list.Add(node);
            Assert.Contains(list, "First Node");
            list.AddAtStart(new Node { Data = "New Start Node" });
            Assert.Contains("New Start Node", "New Start Node");
        }

        public static void TestRemoveNode()
        {
            var list = new LinkedList();
            var node1 = new Node { Data = "Node 1" };
            var node2 = new Node { Data = "Node 2" };
            list.Add(node1);
            list.Add(node2);

            list.Remove(node1);
            Assert.DoesNotContain(list, "Node 1");
        }

        public static void TestSearchListNode()
        {
            var list = new LinkedList();
            var node = new Node { Data = "Target" };
            list.Add(node);
            var result = list.SearchNode("Target");
            Assert.Equal(result.Data, "Target");
        }
    }
}