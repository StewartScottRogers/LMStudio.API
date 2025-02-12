public class WhileStatement : IAstNode
{
    public readonly Expression Condition;
    public readonly List<IAstNode> StatementList;

    public WhileStatement(Expression condition, List<IAstNode> statementList)
    {
        Condition = condition ?? throw new ArgumentNullException(nameof(condition));
        StatementList = statementList ?? throw new ArgumentNullException(nameof(statementList));
    }

    public void Accept(IPrettyPrinter visitor) => visitor.VisitWhileStatement(this);
}