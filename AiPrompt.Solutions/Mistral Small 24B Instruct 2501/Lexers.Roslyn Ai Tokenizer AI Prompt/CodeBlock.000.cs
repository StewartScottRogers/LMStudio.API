using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynAstGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            var code = "class Sample { public int Id { get; set; } }";
            var astGenerator = new AstGenerator();
            
            var syntaxTree = astGenerator.GenerateAst(code);
            var prettyPrintedAst = astGenerator.PrettyPrint(syntaxTree);

            Console.WriteLine("Pretty Printed AST:");
            Console.WriteLine(prettyPrintedAst);
            
            // Reflow the code and execute
            var executableCode = astGenerator.ReflowToExecutableCode(syntaxTree);
            Console.WriteLine("Reflowed Executable Code:");
            Console.WriteLine(executableCode);
        }
    }
}