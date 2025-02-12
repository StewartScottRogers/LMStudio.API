using System.Collections.Generic;

namespace PythonLexer.Nodes.Expressions
{
    public sealed class BinaryExpressionNode : INode
    {
        public readonly INode Left;
        public readonly TokenKind Operator;
        public readonly INode Right;

        public BinaryExpressionNode(INode left, TokenKind op, INode right)
        {
            this.Left = left ?? throw new ArgumentNullException(nameof(left));
            this.Operator = op;
            this.Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }
}