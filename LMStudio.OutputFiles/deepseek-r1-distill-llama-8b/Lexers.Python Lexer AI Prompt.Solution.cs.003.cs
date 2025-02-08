using System.Text;
using System.Collections.Generic;

public class PrettyPrinter : IPrettyPrinter
{
    private readonly StringBuilder sb;
    private int indentLevel = 0;

    public string Print(ASTNode node)
    {
        sb.Clear();
        PrintHelper(node, 0);
        return sb.ToString();
    }

    private void PrintHelper(AbstractNode node, int level)
    {
        if (node is Ast.FunctionDef)
            PrintFunctionDef((Ast.FunctionDef)node, level);
        else if (node is Ast.IfStmt)
            PrintIfStmt((Ast>IfStmt)node, level);
        // Add other print methods for different node types
    }

    private void PrintFunctionDef(Ast.FunctionDef node, int level)
    {
        sb.Append("def ");
        sb.Append(node.Name);
        if (node.Parameters != null && node.Parameters.Count > 0)
        {
            sb.Append("(");
            foreach (var parameter in node.Parameters)
                PrintParameter(parameter, level + 1);
            sb.Append(")");
        }
        sb.Append(":");
    }

    private void PrintParameter(Ast.Parameter node, int level)
    {
        // Parameter printing logic here
    }
}