using System.Collections.Generic;
using System.Linq;

namespace LexerLibrary
{
    /// <summary>
    /// Represents the root program node in an AST.
    /// </summary>
    public record ProgramNode(List<AstNode> StatementList) : AstNode
    {
        /// <summary>
        /// Pretty prints this node and its children to a string.
        /// </summary>
        /// <returns>A formatted string representation of this node.</returns>
        public override string PrettyPrint()
        {
            var builder = new System.Text.StringBuilder();
            builder.AppendLine("Program:");
            
            foreach (var statement in StatementList)
            {
                builder.Append(statement.PrettyPrint());
            }
            
            return builder.ToString();
        }
    }
}