namespace LexerLibrary
{
    public record AssignStmt(string Identifier, Expr Expression) : ASTNode;
}