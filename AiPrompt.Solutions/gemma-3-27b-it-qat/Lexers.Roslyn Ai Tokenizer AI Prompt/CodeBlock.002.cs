namespace AstGenerator.Core;

public interface IExpressionVisitor
{
    void Visit(ExpressionRecord expressionTuple);
    void Visit(StatementRecord statementTuple);
}