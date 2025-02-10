// IAstNode.cs

namespace LexerLibrary
{
    public interface IAstNode
    {
        void Accept(AstVisitor visitor);
    }
}