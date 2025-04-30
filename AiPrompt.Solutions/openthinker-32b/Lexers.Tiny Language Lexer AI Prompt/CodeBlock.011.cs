public record Expression : ASTNode
{
    public Term Left { get; }
    public Token Operator { get; }
    public Expression Right { get; }

    public Expression(Term left, Token @operator, Expression right)
    {
        Left = left;
        Operator = @operator;
        Right = right;
    }

    public Expression(Term term) // For unary expressions or single terms
    {
        Left = term;
        Operator = null;
        Right = null;
    }

    public void Accept(IVisitor visitor) => visitor.VisitExpression(this);
}