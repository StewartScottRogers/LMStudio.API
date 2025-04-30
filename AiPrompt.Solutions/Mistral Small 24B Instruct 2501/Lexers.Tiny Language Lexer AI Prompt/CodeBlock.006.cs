namespace LexerLibrary
{
    public record WhileStmt(Expr Condition, List<ASTNode> Statements) : ASTNode;
}