namespace LexerLibrary;

public class IdentifierNode : AstNode
{
    public string Value { get; set; }

    public IdentifierNode()
    {
        NodeType = AstNodeType.Identifier;
    }
}