using System.Collections.Generic;

namespace LexerLibrary
{
    /// <summary>
    /// Base abstract class for all AST nodes.
    /// </summary>
    public abstract record AstNode
    {
        /// <summary>
        /// Gets the line number where this node appears in the source code.
        /// </summary>
        public int LineNumber { get; init; }

        /// <summary>
        /// Pretty prints this node and its children to a string.
        /// </summary>
        /// <returns>A formatted string representation of this node.</returns>
        public abstract string PrettyPrint();
    }
}