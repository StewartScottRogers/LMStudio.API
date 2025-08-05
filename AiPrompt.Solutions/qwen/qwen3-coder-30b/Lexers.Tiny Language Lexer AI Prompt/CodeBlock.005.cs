namespace LexerLibrary
{
    /// <summary>
    /// Represents a statement node in an AST.
    /// </summary>
    public record StatementNode : AstNode
    {
        /// <summary>
        /// Gets or sets the type of statement.
        /// </summary>
        public StatementType StatementType { get; init; }

        /// <summary>
        /// Gets or sets the expression associated with this statement (for assignments, conditions).
        /// </summary>
        public AstNode Expression { get; init; }

        /// <summary>
        /// Gets or sets the list of statements for control structures.
        /// </summary>
        public List<AstNode> StatementList { get; init; }

        /// <summary>
        /// Pretty prints this node and its children to a string.
        /// </summary>
        /// <returns>A formatted string representation of this node.</returns>
        public override string PrettyPrint()
        {
            return StatementType switch
            {
                StatementType.Assign => $"  Assign: {Expression.PrettyPrint()}\n",
                StatementType.If => $"  If: {Expression.PrettyPrint()}\n    Then:\n{string.Join("", StatementList.Select(s => s.PrettyPrint()))}",
                StatementType.While => $"  While: {Expression.PrettyPrint()}\n    Do:\n{string.Join("", StatementList.Select(s => s.PrettyPrint()))}",
                StatementType.Print => $"  Print: {Expression.PrettyPrint()}\n",
                _ => string.Empty
            };
        }
    }

    /// <summary>
    /// Enumeration of statement types.
    /// </summary>
    public enum StatementType
    {
        Assign,
        If,
        While,
        Print
    }
}