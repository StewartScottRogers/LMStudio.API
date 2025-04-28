// LinkedListNode.cs
using System;

namespace LinkedListDataStructure
{
    public class LinkedListNode
    {
        public int Data { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(int data)
        {
            Data = data;
            Next = null;
        }
    }
}