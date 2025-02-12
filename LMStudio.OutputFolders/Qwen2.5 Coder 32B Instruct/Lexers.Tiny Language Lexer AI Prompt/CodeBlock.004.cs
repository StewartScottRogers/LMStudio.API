public interface IAstNode
{
    void Accept(IPrettyPrinter visitor);
}