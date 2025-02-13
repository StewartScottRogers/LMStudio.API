// StatementNode.cs
public abstract class StatementNode
{
    public abstract string Accept(IStatementVisitor visitor);
}

// IStatementVisitor.cs
public interface IStatementVisitor<T>
{
    T VisitStatementList(StatementListNode node);
    T VisitAssignStatement(AssignStatementNode node);
    T VisitIfStatement(IfStatementNode node);
    T VisitWhileStatement(WhileStatementNode node);
    T VisitPrintStatement(PrintStatementNode node);
}

// ExpressionNode.cs
public abstract class ExpressionNode
{
    public abstract string Accept(IExpressionVisitor visitor);
}

// IExpressionVisitor.cs
public interface IExpressionVisitor<T>
{
    T VisitBinaryExpression(BinaryExpressionNode node);
    T VisitGroupingExpression(GroupingExpressionNode node);
    T VisitNumber(NumberNode numberNode);
    T VisitIdentifier(IdentifierNode identifierNode);
}