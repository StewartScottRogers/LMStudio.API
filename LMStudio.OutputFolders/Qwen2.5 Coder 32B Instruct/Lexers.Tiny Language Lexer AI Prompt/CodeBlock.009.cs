public abstract class Expression : IAstNode
{
    public abstract void Accept(IPrettyPrinter visitor);
}