using System;
using System.Collections.Generic;

namespace LexerProject
{
    public abstract class AbstractSyntaxTreeNode
    {
        // Common properties or methods for all AST nodes can be defined here.
        public readonly string NodeType;

        protected AbstractSyntaxTreeNode(string nodeType)
        {
            NodeType = nodeType;
        }

        public override string ToString()
        {
            return $"{NodeType}";
        }
    }

### File: Statements/Statements.cs