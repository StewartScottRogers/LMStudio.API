// AstGenerator/AstGeneratorClass.cs
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstGenerator
{
    public class AstGeneratorClass
    {
        private readonly string sourceCode;

        public AstGeneratorClass(string sourceCode)
        {
            this.sourceCode = sourceCode;
        }

        public CompilationUnitSyntax GenerateAstTuple()
        {
            // Parse the C# code into a Syntax Tree.
            var tree = CSharpSyntaxTree.ParseText(this.sourceCode);

            // Get the CompilationUnitSyntax (root of the AST).
            CompilationUnitSyntax compilationUnitSyntax = tree.GetCompilationUnitRoot();

            return compilationUnitSyntax;
        }
    }
}