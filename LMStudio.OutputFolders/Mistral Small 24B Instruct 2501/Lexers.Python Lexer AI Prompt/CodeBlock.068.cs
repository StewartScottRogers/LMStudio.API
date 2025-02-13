/// <summary>
/// Represents an Abstract Syntax Tree (AST) Node.
/// </summary>
public interface INode
{
    /// <summary>
    /// Gets the type of this AST node.
    /// </summary>
    string Type { get; }

    /// <summary>
    /// Accepts a visitor.
    /// </summary>
    /// <param name="visitor">The visitor.</param>
    void Accept(IVisitor visitor);
}