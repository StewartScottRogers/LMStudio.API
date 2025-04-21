namespace LexerLibrary;

public class AssignStatementNode : AstNode
{
    public string Identifier { get; set; }
    public ExpressionNode Expression { get; set; }

    public AssignStatementNode()
    {
        NodeType = AstNodeType.AssignStatement;
    }
}