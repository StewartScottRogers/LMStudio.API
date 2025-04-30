using System;
using RoslynASTGenerator;

namespace RoslynASTGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = "Console.WriteLine(\"Hello World\");";
            var astPrinter = new AbstractSyntaxTreePrinter();
            var astReflow = new AbstractSyntaxTreeReflow();

            var syntaxTreeTuple = astReflow.GenerateAbstractSyntaxTree(code);
            Console.WriteLine(astPrinter.PrettyPrint(syntaxTreeTuple.SyntaxTree));

            astReflow.ExecuteGeneratedCode(syntaxTreeTuple.CompilationUnit);
        }
    }
}