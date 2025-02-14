using System;

namespace AstGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var ast = new AbstractSyntaxTree { RootNode = "TestClass" };
            
            IAstPrinter printer = new AstPrettyPrinter();
            printer.Print(ast);
            
            IAstReflowGenerator reflowGenerator = new AstReflowGenerator();
            string code = reflowGenerator.GenerateCode(ast);

            Console.WriteLine("Generated Code:");
            Console.WriteLine(code);
        }
    }
}