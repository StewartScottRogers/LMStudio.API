public record Factor : ASTNode
{
    public Token Value { get; }
    public Expression Expression { get; } // For parenthesized expressions

    public Factor(Token value)
    {
        Value = value;
        Expression = null;
    }

    public Factor(Expression expression) // For parenthesized expressions
    {
        Value = null;
        Expression = expression;
    }

    public void Accept(IVisitor visitor) => visitor.VisitFactor(this);
}