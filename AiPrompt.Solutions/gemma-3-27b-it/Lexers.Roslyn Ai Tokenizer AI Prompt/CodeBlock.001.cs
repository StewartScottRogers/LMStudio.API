// AstPrettyPrinter/AstPrettyPrinterClass.cs
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstPrettyPrinter
{
    public class AstPrettyPrinterClass
    {
        private readonly CompilationUnitSyntax compilationUnitSyntax;

        public AstPrettyPrinterClass(CompilationUnitSyntax compilationUnitSyntax)
        {
            this.compilationUnitSyntax = compilationUnitSyntax;
        }

        public string PrettyPrintAstTuple()
        {
            // Format the AST for readability.
            return this.compilationUnitSyntax.ToFullString();
        }
    }
}