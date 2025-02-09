using System.Collections.Generic;

namespace PythonAST
{
    public sealed record Statement : Node
    {
        public readonly List<Node> Statements { get; init; }

        public Statement(List<Node> statements)
        {
            Statements = statements;
        }
    }
}