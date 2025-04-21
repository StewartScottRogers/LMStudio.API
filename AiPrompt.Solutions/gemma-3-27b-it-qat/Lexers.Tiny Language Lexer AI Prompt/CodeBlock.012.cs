namespace LexerLibrary;

public class FactorNode : AstNode
{
    public IdentifierNode Identifier { get; set; }
    public NumberNode Number { get; set; }
    public ExpressionNode Expression { get; set; }

    public FactorNode()
    {
        NodeType = AstNodeType.Factor;
    }
}