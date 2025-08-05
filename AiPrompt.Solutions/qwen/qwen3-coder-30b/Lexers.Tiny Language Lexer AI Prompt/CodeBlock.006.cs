using System.Collections.Generic;

namespace LexerLibrary
{
    /// <summary>
    /// Represents an expression node in an AST.
    /// </summary>
    public record ExpressionNode : AstNode
    {
        /// <summary>
        /// Gets or sets the type of expression.
        /// </summary>
        public ExpressionType ExpressionType { get; init; }

        /// <summary>
        /// Gets or sets the left operand for binary operations.
        /// </summary>
        public AstNode LeftOperand { get; init; }

        /// <summary>
        /// Gets or sets the right operand for binary operations.
        /// </summary>
        public AstNode RightOperand { get; init; }

        /// <summary>
        /// Gets or sets the value for terminal nodes (identifiers, numbers).
        /// </summary>
        public string Value { get; init; }

        /// <summary>
        /// Pretty prints this node and its children to a string.
        /// </summary>
        /// <returns>A formatted string representation of this node.</returns>
        public override string PrettyPrint()
        {
            return ExpressionType switch
            {
                ExpressionType.Terminal => Value,
                ExpressionType.Addition => $"{LeftOperand.PrettyPrint()} + {RightOperand.PrettyPrint()}",
                ExpressionType.Subtraction => $"{LeftOperand.PrettyPrint()} - {RightOperand.PrettyPrint()}",
                ExpressionType.Multiplication => $"{LeftOperand.PrettyPrint()} * {RightOperand.PrettyPrint()}",
                ExpressionType.Division => $"{LeftOperand.PrettyPrint()} / {RightOperand.PrettyPrint()}",
                _ => string.Empty
            };
        }
    }

    /// <summary>
    /// Enumeration of expression types.
    /// </summary>
    public enum ExpressionType
    {
        Terminal,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}