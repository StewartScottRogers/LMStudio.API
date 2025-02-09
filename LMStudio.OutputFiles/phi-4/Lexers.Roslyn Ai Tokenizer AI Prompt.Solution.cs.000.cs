// AstGenerator.cs
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace RoslynAiTokenizer
{
    public class AstGenerator
    {
        private readonly string _sourceCode;

        public AstGenerator(string sourceCode)
        {
            _sourceCode = sourceCode ?? throw new ArgumentNullException(nameof(sourceCode));
        }

        public SyntaxTree GenerateAst() => CSharpSyntaxTree.ParseText(_sourceCode);

        public void PrintAst(SyntaxTree syntaxTree) =>
            Console.WriteLine(syntaxTree.ToString());
    }
}