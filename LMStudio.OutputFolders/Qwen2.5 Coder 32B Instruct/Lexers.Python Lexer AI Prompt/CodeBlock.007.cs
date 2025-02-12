using System.Collections.Generic;

namespace PythonLexer.Nodes.Statements
{
    public abstract class SimpleStatementNode : INode { }

    public sealed class ExpressionStatementNode : SimpleStatementNode
    {
        public readonly INode Expression;

        public ExpressionStatementNode(INode expression)
        {
            this.Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
    }

    public sealed class ReturnStatementNode : SimpleStatementNode
    {
        public readonly INode Expression;

        public ReturnStatementNode(INode expression)
        {
            this.Expression = expression;
        }
    }
}