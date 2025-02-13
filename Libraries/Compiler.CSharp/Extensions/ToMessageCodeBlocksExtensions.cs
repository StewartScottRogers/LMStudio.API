using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Text;


namespace Compiler.CSharp.Extensions
{
    public static class ToMessageCodeBlocksExtensions
    {
        public static string ToFormattedSyntaxTree(this SyntaxNode syntaxNode, int indent = 0, StringBuilder stringBuilder = null)
        {
            if (stringBuilder is null)
                stringBuilder = new StringBuilder();

            stringBuilder
                .AppendLine(syntaxNode.ToNodeDisplay(indent));

            foreach (SyntaxNodeOrToken syntaxNodeOrToken in syntaxNode.ChildNodesAndTokens())
                if (syntaxNodeOrToken.IsNode)
                {
                    SyntaxNode? childSyntaxNode =
                        syntaxNodeOrToken
                            .AsNode();

                    if (childSyntaxNode is not null)
                        stringBuilder
                            .AppendLine(
                                childSyntaxNode
                                    .ToFormattedSyntaxTree(
                                        indent + 1
                                    ).Trim()
                            );
                }
                else
                    stringBuilder
                        .AppendLine(syntaxNode.ToNodeDisplay(indent));

            return stringBuilder.ToString();
        }

        public static string ToNodeDisplay(this SyntaxNode syntaxNode, int indent)
            => $"{indent:000000} {new string('-', indent)}{syntaxNode.Kind()}".Trim();
    }
}
