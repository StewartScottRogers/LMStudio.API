public class AssignmentStatement : IAstNode
{
    public readonly string Identifier;
    public readonly Expression Expression;

    public AssignmentStatement(string identifier, Expression expression)
    {
        Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    public void Accept(IPrettyPrinter visitor) => visitor.VisitAssignmentStatement(this);
}