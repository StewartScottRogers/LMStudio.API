public class AstPrettyPrinter
{
    public static string Print(SyntaxNode node)
    {
        var sb = new StringBuilder();
        Visit(node, 0, sb);
        return sb.ToString();
    }

    private static void Visit(SyntaxNode node, int depth, StringBuilder sb)
    {
        // Indent based on depth
        for (int i = 0; i < depth; i++) { sb.Append("  "); }
        // Append the node type and any relevant info
        sb.AppendLine(node.GetType().Name);
        foreach (var child in node.ChildNodesAndTokens())
        {
            if (child.IsNode)
                Visit(child.AsNode()!, depth + 1, sb);
            else if (child.IsToken && !child.AsToken().IsKind(SyntaxKind.None))
            {
                // Append token info
                sb.Append(new string(' ', depth * 2));
                sb.AppendLine($"Token: {child.AsToken()} ({child.RawKind})");
            }
        }
    }
}