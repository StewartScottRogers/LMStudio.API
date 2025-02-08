using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace RoslynAiTokenizer.Services
{
    public class AbstractSyntaxTreePrettyPrinter : Models.IAbstractSyntaxTreePrettyPrinter
    {
        private readonly StringBuilder prettyPrintBuilder = new();

        public string PrettyPrint(CSharpSyntaxNode astNode)
        {
            prettyPrintBuilder.Clear();
            VisitNode(astNode, 0);
            return prettyPrintBuilder.ToString();
        }

        private void VisitNode(SyntaxNode node, int indentLevel)
        {
            if (node == null) return;

            prettyPrintBuilder.Append(new string(' ', indentLevel * 4));
            prettyPrintBuilder.AppendLine(node.GetType().Name);

            foreach (var child in node.ChildNodes())
                VisitNode(child, indentLevel + 1);
        }
    }
}