using System.Collections.Generic;

public abstract class StatementNode
{
    public virtual void Accept(IAstVisitor visitor)
    {
        visitor.Visit(this);
    }
}