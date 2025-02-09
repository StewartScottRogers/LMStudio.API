// AstPrettyPrinter.cs
using Microsoft.CodeAnalysis;
using System;

namespace RoslynAiTokenizer
{
    public class AstPrettyPrinter
    {
        public void Print(SyntaxTree syntaxTree) =>
            Console.WriteLine(syntaxTree.ToString());
    }
}