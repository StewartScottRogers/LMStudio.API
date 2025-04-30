using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator
{
    public class AstGenerator : ICodeGenerator
    {
        public SyntaxTree GenerateAst(string code)
        {
            return CSharpSyntaxTree.ParseText(code);
        }

        public string PrettyPrint(SyntaxTree syntaxTree)
        {
            var prettyPrinter = new AstPrettyPrinter();
            return prettyPrinter.Print(syntaxTree.GetRoot());
        }

        public string ReflowToExecutableCode(SyntaxTree syntaxTree)
        {
            var reflowGenerator = new AstReflowGenerator();
            return reflowGenerator.Reflow(syntaxTree.GetRoot());
        }
    }
}