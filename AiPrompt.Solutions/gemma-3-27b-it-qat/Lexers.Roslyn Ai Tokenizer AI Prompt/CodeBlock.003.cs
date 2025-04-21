namespace AstGenerator.Core;

public record ExpressionRecord(string Value, NodeType NodeTypeValue) : IExpressionVisitor
{
    public void Visit(ExpressionRecord expressionTuple)
    {
        // Implement visitor logic if needed
    }

    public void Visit(StatementRecord statementTuple)
    {
        // Implement visitor logic if needed
    }
}