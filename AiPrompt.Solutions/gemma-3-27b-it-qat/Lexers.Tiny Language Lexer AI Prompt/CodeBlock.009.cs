namespace LexerLibrary;

public class PrintStatementNode : AstNode
{
    public ExpressionNode Expression { get; set; }

    public PrintStatementNode()
    {
        NodeType = AstNodeType.PrintStatement;
    }
}