namespace AstGenerator.Core;

public class AstReflowGenerator
{
    public void Reflow(CompilationUnit compilationUnit, string sourceCode)
    {
        compilationUnit.Reflow(sourceCode);
    }
}