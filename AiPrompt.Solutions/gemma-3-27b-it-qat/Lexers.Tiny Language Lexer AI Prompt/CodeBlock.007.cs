using System.Collections.Generic;

namespace LexerLibrary;

public class IfStatementNode : AstNode
{
    public ExpressionNode Condition { get; set; }
    public StatementListNode ThenBlock { get; set; }

    public IfStatementNode()
    {
        NodeType = AstNodeType.IfStatement;
    }
}