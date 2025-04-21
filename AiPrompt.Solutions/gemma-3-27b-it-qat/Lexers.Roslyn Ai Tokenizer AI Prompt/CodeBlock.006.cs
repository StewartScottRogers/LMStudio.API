namespace AstGenerator.Core;

public class AstPrettyPrinter
{
    public string Print(CompilationUnit compilationUnit)
    {
        return compilationUnit.PrettyPrint();
    }
}