// Example of SyntaxTreeNode Class
public abstract class SyntaxTreeNode : ISyntaxTreeNode
{
    public string Name { get; set; }
    public Type Type { get; set; }
    public int LineNumber { get; set; }
    public int ColumnNumber { get; set; }

    public virtual void Visit(ISyntaxTreeNodeVisitor visitor) {}
}