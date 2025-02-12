public class PrettyPrinter : IPrettyPrinter
{
    private readonly StringBuilder output = new StringBuilder();

    public string GetOutput() => output.ToString();

    public void VisitAssignmentStatement(AssignmentStatement node)
    {
        output.Append(node.Identifier);
        output.Append(" := ");
        node.Expression.Accept(this);
    }

    public void VisitIfStatement(IfStatement node)
    {
        output.Append("if ");
        node.Condition.Accept(this);
        output.AppendLine(" then");
        foreach (var statement in node.StatementList)
        {
            statement.Accept(this);
            output.AppendLine();
        }
        output.Append("end");
    }

    public void VisitWhileStatement(WhileStatement node)
    {
        output.Append("while ");
        node.Condition.Accept(this);
        output.AppendLine(" do");
        foreach (var statement in node.StatementList)
        {
            statement.Accept(this);
            output.AppendLine();
        }
        output.Append("end");
    }

    public void VisitPrintStatement(PrintStatement node)
    {
        output.Append("print ");
        node.Expression.Accept(this);
    }

    public void VisitBinaryExpression(BinaryExpression node)
    {
        output.Append("(");
        node.Left.Accept(this);
        output.Append(" ");
        output.Append(node.OperatorToken.Value);
        output.Append(" ");
        node.Right.Accept(this);
        output.Append(")");
    }

    public void VisitIdentifier(Identifier node)
    {
        output.Append(node.Name);
    }

    public void VisitNumberLiteral(NumberLiteral node)
    {
        output.Append(node.Value);
    }

    public void VisitParenthesizedExpression(ParenthesizedExpression node)
    {
        output.Append("(");
        node.InnerExpression.Accept(this);
        output.Append(")");
    }
}