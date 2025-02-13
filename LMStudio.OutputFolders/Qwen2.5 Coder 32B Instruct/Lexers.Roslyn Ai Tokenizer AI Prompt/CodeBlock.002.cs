using Microsoft.CodeAnalysis.CSharp;
using System.Text;

namespace RoslynAstGenerator.Core
{
    public class AbstractSyntaxTreePrettyPrinter : IAstPrettyPrinter
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        public string PrettyPrint(SyntaxNode node)
        {
            Visit(node);
            return stringBuilder.ToString();
        }

        private void Visit(SyntaxNode node, int indentLevel = 0)
        {
            if (node == null) return;

            stringBuilder.Append(new string(' ', indentLevel * 4));
            stringBuilder.AppendLine($"{node.Kind()} {node}");

            foreach (var child in node.ChildNodes())
                Visit(child, indentLevel + 1);
        }
    }
}