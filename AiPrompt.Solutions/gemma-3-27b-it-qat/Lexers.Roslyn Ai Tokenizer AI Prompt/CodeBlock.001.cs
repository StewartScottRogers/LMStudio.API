namespace AstGenerator.Core;

public abstract class AstNode
{
    public NodeType NodeTypeValue { get; set; } = NodeType.Unknown;
}