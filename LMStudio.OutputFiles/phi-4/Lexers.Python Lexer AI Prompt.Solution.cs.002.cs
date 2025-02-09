using System.Collections.Generic;

public class StatementNode : AstNode
{
    public List<AstNode> Children { get; } = new List<AstNode>();

    public override string ToString()
    {
        // Implement pretty printing logic for statements.
        return "Statement";
    }
}