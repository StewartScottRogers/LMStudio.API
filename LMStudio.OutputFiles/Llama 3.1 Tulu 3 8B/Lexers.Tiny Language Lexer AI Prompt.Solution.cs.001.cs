public abstract class ASTNode
{
    public abstract void Accept(IVisitor visitor);
}

public interface IVisitor
{
    void Visit(ASTNode node);
    void Visit(IdentifierNode node);
    void Visit(NumberLiteralNode node);
    // Add more visit methods as needed for other AST nodes.
}

public class IdentifierNode : ASTNode
{
    public string Value { get; }

    public IdentifierNode(string value)
    {
        Value = value;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
// Similarly, define NumberLiteralNode and other AST node classes.