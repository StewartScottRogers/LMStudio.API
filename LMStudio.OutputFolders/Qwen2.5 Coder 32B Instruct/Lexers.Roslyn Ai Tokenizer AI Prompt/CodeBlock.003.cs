using Microsoft.CodeAnalysis.CSharp;
namespace RoslynAstGenerator.Core
{
    public interface IAstReflowGenerator
    {
        bool ReflowAndExecute(Compilation compilation);
    }
}