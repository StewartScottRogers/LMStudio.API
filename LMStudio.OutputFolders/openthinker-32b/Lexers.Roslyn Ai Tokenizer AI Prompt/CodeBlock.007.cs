using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAstTools
{
    public static class ReflowGenerator
    {
        public static string Generate(SyntaxNode node)
        {
            var builder = new System.Text.StringBuilder();
            Visit(node, builder);
            return builder.ToString();
        }

        private static void Visit(SyntaxNode node, System.Text.StringBuilder builder)
        {
            if (node is LiteralExpressionSyntax literal)
            {
                builder.Append(literal.Token.Text);
                return;
            }
            // Handle other nodes recursively
            else if (node is BinaryExpressionSyntax binary)
            {
                builder.Append("(");
                Visit(binary.Left, builder);
                builder.Append(" ");
                builder.Append(binary.OperatorToken.Text);
                builder.Append(" ");
                Visit(binary.Right, builder);
                builder.Append(")");
                return;
            }
            // Add more cases as needed
        }
    }
}