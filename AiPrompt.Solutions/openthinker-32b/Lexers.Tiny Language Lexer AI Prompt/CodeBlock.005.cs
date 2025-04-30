public record Program : ASTNode
{
    public StatementList Statements { get; }

    public Program(StatementList statements)
    {
        Statements = statements;
    }

    public void Accept(IVisitor visitor) => visitor.VisitProgram(this);
}