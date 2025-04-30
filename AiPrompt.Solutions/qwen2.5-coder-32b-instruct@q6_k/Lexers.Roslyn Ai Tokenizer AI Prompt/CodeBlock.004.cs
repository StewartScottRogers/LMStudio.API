using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAstLibrary
{
    public interface ITestCase
    {
        SyntaxNode TestCaseNode { get; }
    }
}