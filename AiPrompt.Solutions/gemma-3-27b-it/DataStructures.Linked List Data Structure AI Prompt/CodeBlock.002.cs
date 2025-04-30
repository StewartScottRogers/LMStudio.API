// LinkedListNode.cs
using System;

namespace LinkedListDataStructure
{
    public class LinkedListNode
    {
        private readonly object data;
        private LinkedListNode nextNode;

        public LinkedListNode(object data)
        {
            this.data = data;
            this.nextNode = null;
        }

        public object Data => this.data;
        public LinkedListNode NextNode
        {
            get { return this.nextNode; }
            set { this.nextNode = value; }
        }
    }
}