using System;
using System.Collections.Generic;

namespace LexerLib
{
    public abstract class AbstractSyntaxTreeNode
    {
        public string NodeType { get; protected set; }
        public List<AbstractSyntaxTreeNode> Children { get; private set; }

        public AbstractSyntaxTreeNode()
        {
            Children = new List<AbstractSyntaxTreeNode>();
        }

        public void AddChild(AbstractSyntaxTreeNode child)
        {
            if (child != null)
            {
                Children.Add(child);
            }
        }
    }
}

# Node Classes
// NOTE: Implement the following node classes based on the grammar provided. Each class represents a specific type of node in the Abstract Syntax Tree (AST).