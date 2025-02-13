namespace RoslynAstGenerator.Core
{
    public interface IAstPrettyPrinter
    {
        string PrettyPrint(SyntaxNode node);
    }
}