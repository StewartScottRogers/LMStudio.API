using Microsoft.CodeAnalysis;

namespace RoslynAstGenerator
{
    public interface ICodeGenerator
    {
        SyntaxTree GenerateAst(string code);
        
        string PrettyPrint(SyntaxTree syntaxTree);
        
        string ReflowToExecutableCode(SyntaxTree syntaxTree);
    }
}