using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Emit;

namespace RoslynAstGenerator.Core
{
    public class AbstractSyntaxTreeReflowGenerator : IAstReflowGenerator
    {
        private readonly string outputAssemblyPath = "Program.exe";

        public bool ReflowAndExecute(Compilation compilation)
        {
            using (var outputAssemblyStream = new FileStream(outputAssemblyPath, FileMode.Create))
            {
                EmitResult result = compilation.Emit(outputAssemblyStream);
                if (!result.Success)
                {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (var diagnostic in failures)
                    {
                        System.Console.WriteLine($"{diagnostic.Id}: {diagnostic.GetMessage()}");
                    }
                    return false;
                }
            }

            System.Reflection.Assembly.LoadFrom(outputAssemblyPath).EntryPoint?.Invoke(null, new object[] { null });
            return true;
        }
    }
}