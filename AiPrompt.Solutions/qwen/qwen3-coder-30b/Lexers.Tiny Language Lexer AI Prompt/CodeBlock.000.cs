namespace LexerLibrary
{
    /// <summary>
    /// Represents a token in the source code with its type and value.
    /// </summary>
    public record Token(TokenType TokenType, string Value);
}