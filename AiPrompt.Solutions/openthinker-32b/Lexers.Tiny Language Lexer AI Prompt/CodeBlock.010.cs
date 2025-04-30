public record PrintStatement : ASTNode
{
    public Expression Expression { get; }

    public PrintStatement(Expression expression)
    {
        Expression = expression;
    }

    public void Accept(IVisitor visitor) => visitor.VisitPrintStatement(this);
}