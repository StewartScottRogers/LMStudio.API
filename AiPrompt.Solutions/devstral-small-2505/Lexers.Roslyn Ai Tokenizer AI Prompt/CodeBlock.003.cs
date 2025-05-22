using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace MyAstApp
{
    public static class RoslynHelper
    {
        public static void Execute(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilation = CSharpCompilation.Create("DynamicAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
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
                var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(ms);

                // Assuming ExampleNamespace.ExampleClass exists
                var exampleType = assembly.GetType("ExampleNamespace.ExampleClass");
                if (exampleType != null)
                {
                    var instance = Activator.CreateInstance(exampleType);
                    var methodInfo = exampleType.GetMethod("Add", new[] { typeof(int), typeof(int) });
                    var resultValue = methodInfo.Invoke(instance, new object[] { 10, 20 });
                    Console.WriteLine(resultValue);
                }
            }
        }
    }
}