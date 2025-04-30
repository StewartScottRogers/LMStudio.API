using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAstLibrary
{
    public class AbstractSyntaxTreePrinter
    {
        public void Print(SyntaxNode node, int indent = 0)
        {
            if (node == null) return;

            Console.WriteLine($"{new string(' ', indent * 2)}{node.Kind()}: {node}");
            foreach (var child in node.ChildNodes())
                Print(child, indent + 1);
        }
    }
}