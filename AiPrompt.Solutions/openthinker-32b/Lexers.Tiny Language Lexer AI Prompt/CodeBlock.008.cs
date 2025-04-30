public record IfStatement : ASTNode
{
    public Expression Condition { get; }
    public StatementList Body { get; }

    public IfStatement(Expression condition, StatementList body)
    {
        Condition = condition;
        Body = body;
    }

    public void Accept(IVisitor visitor) => visitor.VisitIfStatement(this);
}