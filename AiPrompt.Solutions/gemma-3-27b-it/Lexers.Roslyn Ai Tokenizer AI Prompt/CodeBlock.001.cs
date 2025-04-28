using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Text;

namespace AstReflowGenerator
{
    public class AbstractSyntaxTreeReflowGenerator
    {
        public string GenerateCode(SyntaxNode node)
        {
            // This is a very basic example.  A full implementation would involve more complex AST traversal and code generation logic.
            var compilationUnit = (CompilationUnitSyntax)node;

            using var writer = new StringWriter();
            compilationUnit.WriteTo(writer, null); // Use Roslyn's built-in formatting
            return writer.ToString();
        }
    }
}