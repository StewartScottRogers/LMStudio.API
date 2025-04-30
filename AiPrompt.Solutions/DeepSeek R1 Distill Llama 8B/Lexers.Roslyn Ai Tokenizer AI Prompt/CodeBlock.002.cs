using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Emit;
using System.Reflection;

namespace RoslynASTGenerator
{
    public readonly class AbstractSyntaxTreeReflow
    {
        public (Compilation CompilationUnit, SyntaxTree SyntaxTree) GenerateAbstractSyntaxTree(string code)
        {
            var syntaxTree = CSharpScript.Parse(code).GetSyntaxTreeAsync().Result;
            var compilation = CSharpCompilation.Create(
                "GeneratedCode",
                new[] { syntaxTree },
                new[]
                {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Console).Assembly.Location)
                },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));

            return (compilation, syntaxTree);
        }

        public void ExecuteGeneratedCode(Compilation compilationUnit)
        {
            using var ms = new System.IO.MemoryStream();
            EmitResult result = compilationUnit.Emit(ms);

            if (!result.Success)
            {
                var errors = result.Diagnostics.Where(diag => diag.IsWarningAsError || diag.Severity == DiagnosticSeverity.Error);
                foreach (var diagnostic in errors)
                    Console.WriteLine($"{diagnostic.Id}: {diagnostic.GetMessage()}");
            }
            else
            {
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                Assembly assembly = Assembly.Load(ms.ToArray());
                var entryPointMethod = assembly.EntryPoint;
                if (entryPointMethod != null)
                {
                    entryPointMethod.Invoke(null, new object[] { });
                }
            }
        }
    }
}