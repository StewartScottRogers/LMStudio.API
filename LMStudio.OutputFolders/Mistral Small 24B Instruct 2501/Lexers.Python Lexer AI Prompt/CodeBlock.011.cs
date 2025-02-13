using Microsoft.CSharp;

public abstract class AstNode
{
    public virtual void Accept(IAstVisitor visitor)
    {
        throw new System.NotImplementedException();
    }
}

public interface IAstVisitor
{
    void Visit(AstNode node);
}