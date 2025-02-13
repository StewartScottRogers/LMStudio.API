using System;

namespace LexerLibrary
{
    public abstract class AbstractSyntaxTreeNode
    {
        // Common properties and methods for all AST nodes can go here.
        public readonly string NodeType;
        protected AbstractSyntaxTreeNode(string nodeType)
        {
            NodeType = nodeType;
        }
    }
}