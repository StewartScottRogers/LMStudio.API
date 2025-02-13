// Nodes/StatementListNode.cs
public class StatementListNode : StatementNode
{
    public readonly List<StatementNode> Statements;

    public StatementListNode(List<StatementNode> statements)
    {
        Statements = statements;
    }

    public override string Accept(IStatementVisitor visitor) => visitor.VisitStatementList(this);
}

// Nodes/AssignStatementNode.cs
public class AssignStatementNode : StatementNode
{
    public readonly IdentifierNode Identifier;
    public readonly ExpressionNode Expression;

    public AssignStatementNode(IdentifierNode identifier, ExpressionNode expression)
    {
        Identifier = identifier;
        Expression = expression;
    }

    public override string Accept(IStatementVisitor visitor) => visitor.VisitAssignStatement(this);
}

// Nodes/IfStatementNode.cs
public class IfStatementNode : StatementNode
{
    public readonly ExpressionNode Condition;
    public readonly StatementListNode ThenBranch;

    public IfStatementNode(ExpressionNode condition, StatementListNode thenBranch)
    {
        Condition = condition;
        ThenBranch = thenBranch;
    }

    public override string Accept(IStatementVisitor visitor) => visitor.VisitIfStatement(this);
}

// Nodes/WhileStatementNode.cs
public class WhileStatementNode : StatementNode
{
    public readonly ExpressionNode Condition;
    public readonly StatementListNode Body;

    public WhileStatementNode(ExpressionNode condition, StatementListNode body)
    {
        Condition = condition;
        Body = body;
    }

    public override string Accept(IStatementVisitor visitor) => visitor.VisitWhileStatement(this);
}

// Nodes/PrintStatementNode.cs
public class PrintStatementNode : StatementNode
{
    public readonly ExpressionNode Expression;

    public PrintStatementNode(ExpressionNode expression)
    {
        Expression = expression;
    }

    public override string Accept(IStatementVisitor visitor) => visitor.VisitPrintStatement(this);
}