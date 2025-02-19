using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAstTools
{
    public static class AstPrettyPrinter
    {
        public static string Print(SyntaxNode node)
        {
            var stringBuilder = new StringBuilder();
            Visit(node, 0, stringBuilder);
            return stringBuilder.ToString();
        }

        private static void Visit(SyntaxNode node, int depth, StringBuilder builder)
        {
            for (int i = 0; i < depth; i++) { builder.Append("  "); }
            builder.AppendLine($"Node Type: {node.GetType().Name}");

            foreach (var child in node.ChildNodesAndTokens())
            {
                if (child.IsToken && !child.AsToken().IsKind(SyntaxKind.None))
                {
                    var token = child.AsToken();
                    builder.Append(new string(' ', depth * 2));
                    builder.AppendLine($"Token: {token.Text} ({token.RawKind})");
                }
                else if (child.IsNode)
                {
                    Visit(child.AsNode()!, depth + 1, builder);
                }
            }
        }
    }
}