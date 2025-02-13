public readonly record StatementNodeTuple(var statements : List<StatementNode>);

public class StatementNode : PythonNodeBase
{
    public List<StatementNode> Statements { get; set; }

    public StatementNode(List<StatementNode> statements)
    {
        Statements = statements;
    }
}