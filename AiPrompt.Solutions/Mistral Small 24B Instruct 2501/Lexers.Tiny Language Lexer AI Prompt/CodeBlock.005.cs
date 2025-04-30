namespace LexerLibrary
{
    public record IfStmt(Expr Condition, List<ASTNode> Statements) : ASTNode;
}