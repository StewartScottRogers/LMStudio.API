public class AssignNode : Node
{
    public string Identifier { get; }
    public ExprNode Expression { get; }

    public AssignNode(string identifier, ExprNode expression)
    {
        Identifier = identifier;
        Expression = expression;
    }
}