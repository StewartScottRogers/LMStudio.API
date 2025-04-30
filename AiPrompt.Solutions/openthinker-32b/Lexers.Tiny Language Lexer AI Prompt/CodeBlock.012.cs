public record Term : ASTNode
{
    public Factor Left { get; }
    public Token Operator { get; }
    public Term Right { get; }

    public Term(Factor left, Token @operator, Term right)
    {
        Left = left;
        Operator = @operator;
        Right = right;
    }

    public Term(Factor factor) // For unary terms or single factors
    {
        Left = factor;
        Operator = null;
        Right = null;
    }

    public void Accept(IVisitor visitor) => visitor.VisitTerm(this);
}