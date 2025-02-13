using Microsoft.CodeAnalysis;
using System.IO;

namespace RoslynAstGenerator
{
    public static class AstReflowGenerator
    {
        public static string ReflowAstToCode(SyntaxNode ast)
        {
            using (var writer = new StringWriter())
            {
                SyntaxFormatter.Format(ast, writer);
                return writer.ToString();
            }
        }
    }
}