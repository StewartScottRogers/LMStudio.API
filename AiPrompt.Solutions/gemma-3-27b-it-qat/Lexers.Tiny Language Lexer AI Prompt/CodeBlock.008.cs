using System.Collections.Generic;

namespace LexerLibrary;

public class WhileStatementNode : AstNode
{
    public ExpressionNode Condition { get; set; }
    public StatementListNode DoBlock { get; set; }

    public WhileStatementNode()
    {
        NodeType = AstNodeType.WhileStatement;
    }
}