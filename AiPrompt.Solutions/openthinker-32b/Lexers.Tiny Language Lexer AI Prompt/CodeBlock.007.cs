public record AssignmentStatement : ASTNode
{
    public string Identifier { get; }
    public Expression Expression { get; }

    public AssignmentStatement(string identifier, Expression expression)
    {
        Identifier = identifier;
        Expression = expression;
    }

    public void Accept(IVisitor visitor) => visitor.VisitAssignmentStatement(this);
}