using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace RoslynAstGenerator
{
    internal class Program
    {
        private static readonly string CodeSample = @"
            using System;
            namespace ExampleNamespace
            {
                public class ExampleClass
                {
                    public void ExampleMethod()
                    {
                        Console.WriteLine(""Hello, World!"");
                    }
                }
            }";

        private static void Main(string[] args)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(CodeSample);

            // Generate Abstract Syntax Tree
            var ast = AbstractSyntaxTreeGenerator.GenerateAst(syntaxTree);
            Console.WriteLine("Generated AST:");
            Console.WriteLine(AstPrettyPrinter.PrettyPrint(ast));

            // Reflow the AST and execute generated code
            string refloedCode = AstReflowGenerator.ReflowAstToCode(syntaxTree.Root);
            CompileAndExecute(refloedCode);
        }

        private static void CompileAndExecute(string code)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilation = CSharpCompilation.Create("GeneratedAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.ConsoleApplication))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddSyntaxTrees(syntaxTree);

            using (var ms = new System.IO.MemoryStream())
            {
                var result = compilation.Emit(ms);
                if (!result.Success)
                {
                    Console.WriteLine("Compilation failed:");
                    foreach (var diagnostic in result.Diagnostics)
                    {
                        Console.WriteLine(diagnostic.ToString());
                    }
                    return;
                }

                ms.Seek(0, System.IO.SeekOrigin.Begin);
                var assembly = Assembly.Load(ms.ToArray());

                // Find and invoke the Main method
                var mainMethod = assembly.EntryPoint;
                if (mainMethod != null)
                {
                    mainMethod.Invoke(null, new object[] { new string[0] });
                }
            }
        }
    }
}