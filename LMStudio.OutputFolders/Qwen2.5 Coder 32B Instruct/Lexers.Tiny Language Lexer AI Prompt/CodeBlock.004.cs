public class PrettyPrinter : IStatementVisitor<string>, IExpressionVisitor<string>
{
    public string Print(StatementNode statement)
    {
        return statement.Accept(this);
    }

    public string VisitAssignStatement(AssignStatementNode node)
    {
        return $"{node.Identifier.Name} := {VisitExpression(node.Expression)}";
    }

    public string VisitIfStatement(IfStatementNode node)
    {
        var condition = VisitExpression(node.Condition);
        var thenBranch = PrintStatements(node.ThenBranch.Statements);

        return $"if {condition} then\n{thenBranch}\nend";
    }

    public string VisitWhileStatement(WhileStatementNode node)
    {
        var condition = VisitExpression(node.Condition);
        var body = PrintStatements(node.Body.Statements);

        return $"while {condition} do\n{body}\nend";
    }
    
    public string VisitPrintStatement(PrintStatementNode node)
    {
        return $"print {VisitExpression(node.Expression)}";
    }

    private string PrintStatements(List<StatementNode> statements)
    {
        var result = new List<string>();
        foreach (var statement in statements)
            result.Add(statement.Accept(this));

        return string.Join("\n", result);
    }
    
    public string VisitBinaryExpression(BinaryExpressionNode node)
    {
        var left = VisitExpression(node.Left);
        var right = VisitExpression(node.Right);

        return $"({left} {node.Operator.Lexeme} {right})";
    }

    public string VisitGroupingExpression(GroupingExpressionNode node)
    {
        var expression = VisitExpression(node.Expression);

        return $"({expression})";
    }

    public string VisitNumber(NumberNode numberNode)
    {
        return numberNode.Value.ToString();
    }
    
    public string VisitIdentifier(IdentifierNode identifierNode)
    {
        return identifierNode.Name;
    }

    private string VisitExpression(ExpressionNode expression)
    {
        return expression.Accept(this);
    }
}