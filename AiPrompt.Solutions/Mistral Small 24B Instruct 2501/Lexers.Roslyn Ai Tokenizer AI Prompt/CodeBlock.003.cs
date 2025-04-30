using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator
{
    public class AstPrettyPrinter
    {
        public string Print(SyntaxNode node)
        {
            var printer = new System.Text.StringBuilder();
            
            // Simple example of pretty printing, expand as needed
            foreach (var child in node.ChildNodes())
            {
                printer.Append(child.ToFullString());
            }

            return printer.ToString();
        }
    }
}