/// <summary>
    /// Represents an abstract syntax tree node.
    /// </summary>
    public class AstNode 
    {
        /// <summary>
        /// Gets the type of this AST node.
        /// </summary>
        public virtual AstNodeType Type { get; }

        // ...
    }