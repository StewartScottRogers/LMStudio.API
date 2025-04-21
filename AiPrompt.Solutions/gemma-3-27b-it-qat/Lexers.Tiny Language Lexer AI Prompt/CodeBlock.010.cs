namespace LexerLibrary;

public class ExpressionNode : AstNode
{
    public TermNode Left { get; set; }
    public string Operator { get; set; }
    public ExpressionNode Right { get; set; }

    public ExpressionNode()
    {
        NodeType = AstNodeType.Expression;
    }
}