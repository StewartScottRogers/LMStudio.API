// AstPrettyPrinter.cs
public class AstPrettyPrinter
{
    public string Print(AstNode node)
    {
        if (node is ProgramNode programNode)
        {
            return "Program:\n" + PrintStatementList(programNode.StatementList);
        }
        else if (node is StatementListNode statementListNode)
        {
            return PrintStatementList(statementListNode);
        }
        else if (node is AssignStatementNode assignStatementNode)
        {
            return $"Assign: {assignStatementNode.Identifier} := {PrintExpression(assignStatementNode.Expression)}";
        }
        else if (node is IdentifierNode identifierNode)
        {
            return identifierNode.Name;
        }
        else if (node is NumberNode numberNode)
        {
            return numberNode.Value.ToString();
        }

        return "Unknown Node Type"; // Handle other node types as needed
    }

    private string PrintStatementList(StatementListNode statementList)
    {
        string result = "";
        foreach (var statement in statementList.Statements)
        {
            result += Print(statement) + "\n";
        }
        return result;
    }

    private string PrintExpression(ExpressionNode expressionNode)
    {
        // Implement printing for different expression node types as needed
        if (expressionNode is IdentifierNode identifierNode)
        {
            return identifierNode.Name;
        }
        else if (expressionNode is NumberNode numberNode)
        {
            return numberNode.Value.ToString();
        }

        return "Unknown Expression Type";
    }
}