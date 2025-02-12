// Interfaces/IAbstractSyntaxTreeService.cs
using Microsoft.CodeAnalysis.CSharp.Syntax;

public interface IAbstractSyntaxTreeService
{
    CompilationUnitSyntax GenerateAstFromString(string code);
    string PrettyPrint(CompilationUnitSyntax ast);
    string ReflowCode(CompilationUnitSyntax ast);
}