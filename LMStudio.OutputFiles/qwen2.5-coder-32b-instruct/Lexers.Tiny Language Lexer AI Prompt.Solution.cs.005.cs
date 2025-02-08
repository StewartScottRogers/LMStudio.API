using System.Text;

public class PrettyPrinter
{
    public string Print(AstNode node)
    {
        var sb = new StringBuilder();
        if (node is StatementListNode statementList)
            foreach (var stmt in statementList.Statements)
                sb.AppendLine(Print(stmt));
        else if (node is AssignNode assignNode)
            sb.Append($"{assignNode.Name} := {Print(assignNode.Expression)};");
        else if (node is IfNode ifNode)
        {
            sb.AppendLine($"if {Print(ifNode.Condition)} then");
            sb.AppendLine(Print(ifNode.ThenBranch));
            sb.AppendLine("end");
        }
        else if (node is WhileNode whileNode)
        {
            sb.AppendLine($"while {Print(whileNode.Condition)} do");
            sb.AppendLine(Print(whileNode.Body));
            sb.AppendLine("end");
        }
        else if (node is PrintNode printNode)
            sb.Append($"print {Print(printNode.Expression)};");
        else if (node is LiteralNode literalNode)
            sb.Append(literalNode.Value);
        else if (node is VariableNode variableNode)
            sb.Append(variableNode.Name);
        else if (node is GroupingExprNode groupingExprNode)
            sb.Append($"({Print(groupingExprNode.Expression)})");
        else if (node is BinaryExprNode binaryExprNode)
            sb.Append($"{Print(binaryExprNode.Left)} {binaryExprNode.OperatorType} {Print(binaryExprNode.Right)}");
        return sb.ToString();
    }
}