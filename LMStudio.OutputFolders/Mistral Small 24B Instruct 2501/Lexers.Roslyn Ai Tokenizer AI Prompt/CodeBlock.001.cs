using Microsoft.CodeAnalysis;
using System.IO;

namespace RoslynAstGenerator
{
    public static class AstPrettyPrinter
    {
        public static string PrettyPrint(SyntaxNode ast)
        {
            using (var writer = new StringWriter())
            {
                SyntaxVisualizer.Visualize(ast, writer);
                return writer.ToString();
            }
        }
    }
}