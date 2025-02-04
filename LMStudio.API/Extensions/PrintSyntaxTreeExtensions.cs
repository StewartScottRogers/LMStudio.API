using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Text;


namespace LMStudio.API.Extensions
{
    public static class PrintSyntaxTreeExtensions
    {
        public static string ToFormattedSyntaxTree(this SyntaxNode syntaxNode, string indent = "", StringBuilder stringBuilder = null)
        {
            if (stringBuilder is null)
                stringBuilder = new StringBuilder();

            stringBuilder
                .AppendLine($"{indent}{syntaxNode.Kind()} - {syntaxNode}");

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
                                        indent + "  ",
                                        stringBuilder
                                        )
                            );
                }
                else
                    stringBuilder.AppendLine($"{indent}  {syntaxNodeOrToken.Kind()} - {syntaxNodeOrToken}");

            return stringBuilder.ToString();
        }
    }
}
