public interface ASTNode
{
    void Accept(IVisitor visitor);
}