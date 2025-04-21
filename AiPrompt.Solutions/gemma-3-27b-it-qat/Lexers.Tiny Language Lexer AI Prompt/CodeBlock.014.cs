namespace LexerLibrary;

public class NumberNode : AstNode
{
    public string Value { get; set; }

    public NumberNode()
    {
        NodeType = AstNodeType.Number;
    }
}