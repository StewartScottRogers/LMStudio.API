using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;

namespace RoslynAstGenerator.Ast
{
    public readonly record struct AstGenerationResult(Compilation Compilation, string PrettyPrint);

    public class AbstractSyntaxTreeGenerator
    {
        private readonly SyntaxNode rootNode;
        private readonly CSharpCompilation compilation;

        public AbstractSyntaxTreeGenerator(string code)
        {
            this.rootNode = CSharpSyntaxTree.ParseText(code).GetRoot();
            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                .Select(a => MetadataReference.CreateFromFile(a.Location));
            this.compilation = CSharpCompilation.Create(
                "MyCode",
                syntaxTrees: new[] { CSharpSyntaxTree.ParseText(code) },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        }

        public string PrettyPrint()
        {
            return rootNode.ToString();
        }

        public void ReflowAndExecute()
        {
            using var stream = new MemoryStream();
            var emitResult = compilation.Emit(stream);

            if (!emitResult.Success)
            {
                var failures = emitResult.Diagnostics.Where(diagnostic =>
                    diagnostic.IsWarningAsError ||
                    diagnostic.Severity == DiagnosticSeverity.Error);
                foreach (var diagnostic in failures)
                {
                    Console.WriteLine($"  {diagnostic.Id}: {diagnostic.GetMessage()}");
                }
                return;
            }

            stream.Seek(0, SeekOrigin.Begin);

            var assembly = System.Reflection.Assembly.Load(stream.ToArray());
            var type = assembly.GetType("TestNamespace.TestClass");
            var methodInfo = type?.GetMethod("TestMethod");

            if (methodInfo != null)
            {
                var instance = Activator.CreateInstance(type);
                methodInfo.Invoke(instance, new object[] { });
            }
        }
    }
}