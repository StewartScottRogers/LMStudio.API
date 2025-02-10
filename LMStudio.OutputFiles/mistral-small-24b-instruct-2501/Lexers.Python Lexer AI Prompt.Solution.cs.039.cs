using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public abstract class AstNode
    {
        // Properties
        public readonly string NodeName { get; }

        protected AstNode(string nodeName)
        {
            NodeName = nodeName;
        }
    }

    public class AssignmentStatement : AstNode
    {
        // Properties
        public readonly string Target { get; }
        public readonly string Expression { get; }
        public readonly string AnnotatedRhs { get; }

        // Constructor
        public AssignmentStatement(string target, string expression, string annotatedRhs)
            : base("Assignment Statement")
        {
            this.Target = target;
            this.Expression = expression;
            this.AnnotatedRhs = annotatedRhs;
        }
    }

# File: AstNode.cs