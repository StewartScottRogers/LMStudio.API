using System.Text;

public class PrettyPrinter
{
    public string Print(AstNode node)
    {
        var sb = new StringBuilder();
        PrintNode(node, sb, 0);
        return sb.ToString();
    }

    private void PrintNode(AstNode node, StringBuilder sb, int indentLevel)
    {
        if (node is StatementNode statementNode)
        {
            // Example printing logic for statements.
            sb.AppendLine(new string(' ', indentLevel * 2) + "Statement");
            foreach (var child in statementNode.Children)
            {
                PrintNode(child, sb, indentLevel + 1);
            }
        }
    }
}