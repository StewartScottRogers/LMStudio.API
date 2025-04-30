public record StatementList : ASTNode
{
    public List<ASTNode> Statements { get; }

    public StatementList(List<ASTNode> statements)
    {
        Statements = statements;
    }

    public void Accept(IVisitor visitor) => visitor.VisitStatementList(this);
}