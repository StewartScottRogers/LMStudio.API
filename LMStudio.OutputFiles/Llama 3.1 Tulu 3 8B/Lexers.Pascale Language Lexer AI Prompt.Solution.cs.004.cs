public static class AstPrinter
{
    public static string Print(AstNode node, int indentLevel = 0)
    {
        var sb = new StringBuilder();
        Indent(sb, indentLevel).Append(node.Value).AppendLine();
        // Recursive call for child nodes...
        foreach (var child in node.ChildNodes)
            Print(child, indentLevel + 1);
        return sb.ToString();
    }

    private static void Indent(StringBuilder sb, int count)
    {
        for (int i = 0; i < count * 4; ++i)
            sb.Append(' ');
    }
}