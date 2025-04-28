// AstReflowGenerator/AstReflowGeneratorClass.cs
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstReflowGenerator
{
    public class AstReflowGeneratorClass
    {
        private readonly CompilationUnitSyntax compilationUnitSyntax;

        public AstReflowGeneratorClass(CompilationUnitSyntax compilationUnitSyntax)
        {
            this.compilationUnitSyntax = compilationUnitSyntax;
        }

        public string GenerateCodeTuple()
        {
            // Convert the AST back to C# code (basic reflowing).
            return this.compilationUnitSyntax.ToText();
        }
    }
}