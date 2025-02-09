// AstReflowGenerator.cs
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace RoslynAiTokenizer
{
    public class AstReflowGenerator
    {
        private readonly SyntaxTree _syntaxTree;

        public AstReflowGenerator(SyntaxTree syntaxTree)
        {
            _syntaxTree = syntaxTree ?? throw new ArgumentNullException(nameof(syntaxTree));
        }

        public void Execute()
        {
            var compilation = CSharpCompilation.Create("AstExecution")
                .AddSyntaxTrees(_syntaxTree)
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));

            using var ms = new MemoryStream();
            var result = compilation.Emit(ms);

            if (!result.Success)
            {
                Console.WriteLine("Code generation failed.");
                return;
            }

            ms.Seek(0, SeekOrigin.Begin);
            var assembly = Assembly.Load(ms.ToArray());
            var entryType = assembly.GetTypes()[0];
            var method = entryType.GetMethod("Main");

            method.Invoke(null, null);
        }
    }
}