public record WhileStatement : ASTNode
{
    public Expression Condition { get; }
    public StatementList Body { get; }

    public WhileStatement(Expression condition, StatementList body)
    {
        Condition = condition;
        Body = body;
    }

    public void Accept(IVisitor visitor) => visitor.VisitWhileStatement(this);
}