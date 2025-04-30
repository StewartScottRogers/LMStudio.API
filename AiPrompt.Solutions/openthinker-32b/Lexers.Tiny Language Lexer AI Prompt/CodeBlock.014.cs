using System.Text;

public class PrettyPrinter : IVisitor
{
    private StringBuilder output = new StringBuilder();

    public string GetResult() => output.ToString();

    public void VisitProgram(Program program)
    {
        VisitStatementList(program.Statements);
    }

    public void VisitStatementList(StatementList statementList)
    {
        foreach (var statement in statementList.Statements)
            statement.Accept(this);

        output.AppendLine();
    }

    public void VisitAssignmentStatement(AssignmentStatement assignmentStatement)
    {
        output.Append($"{assignmentStatement.Identifier} := ");
        VisitExpression(assignmentStatement.Expression);
        output.AppendLine(";");
    }

    public void VisitIfStatement(IfStatement ifStatement)
    {
        output.Append("if ");
        VisitExpression(ifStatement.Condition);
        output.Append(" then");
        VisitStatementList(ifStatement.Body);
        output.AppendLine("end;");
    }

    public void VisitWhileStatement(WhileStatement whileStatement)
    {
        output.Append("while ");
        VisitExpression(whileStatement.Condition);
        output.Append(" do");
        VisitStatementList(whileStatement.Body);
        output.AppendLine("end;");
    }

    public void VisitPrintStatement(PrintStatement printStatement)
    {
        output.Append("print ");
        VisitExpression(printStatement.Expression);
        output.AppendLine(";");
    }

    private void VisitExpression(Expression expression)
    {
        if (expression.Right == null && expression.Operator == null)
            VisitTerm(expression.Left);
        else
        {
            VisitTerm(expression.Left);
            output.Append($" {expression.Operator.Lexeme} ");
            VisitExpression(expression.Right);
        }
    }

    private void VisitTerm(Term term)
    {
        if (term.Right == null && term.Operator == null)
            VisitFactor(term.Left);
        else
        {
            VisitFactor(term.Left);
            output.Append($" {term.Operator.Lexeme} ");
            VisitTerm(term.Right);
        }
    }

    private void VisitFactor(Factor factor)
    {
        if (factor.Expression != null)
        {
            output.Append("(");
            VisitExpression(factor.Expression);
            output.Append(")");
        }
        else
            output.Append(factor.Value.Literal);
    }
}