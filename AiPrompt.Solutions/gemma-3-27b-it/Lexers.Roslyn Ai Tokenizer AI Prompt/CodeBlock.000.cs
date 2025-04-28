using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Text;

namespace AstPrettyPrinter
{
    public class AbstractSyntaxTreePrettyPrinter
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();
        private readonly int indentLevel;

        public AbstractSyntaxTreePrettyPrinter(int indentLevel = 0)
        {
            this.indentLevel = indentLevel;
        }

        public string Print(SyntaxNode node)
        {
            stringBuilder.Clear();
            PrintSyntaxNode(node);
            return stringBuilder.ToString();
        }

        private void PrintSyntaxNode(SyntaxNode node, int currentIndentLevel = 0)
        {
            string indent = new string(' ', currentIndentLevel * 4);
            stringBuilder.AppendLine($"{indent}{node.GetType().Name}: {node}");

            if (node is SyntaxList<SyntaxNode> syntaxList)
            {
                foreach (var child in syntaxList)
                {
                    PrintSyntaxNode(child, currentIndentLevel + 1);
                }
            }
            else if (node.HasChildNodes())
            {
                foreach (var child in node.GetChildNodesAndTokens())
                {
                    if (child is SyntaxNode syntaxNode)
                    {
                        PrintSyntaxNode(syntaxNode, currentIndentLevel + 1);
                    }
                }
            }
        }
    }
}