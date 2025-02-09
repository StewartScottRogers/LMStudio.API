namespace PythonLexer
{
    public enum TokenType
    {
        Name,
        Number,
        String,
        Operator,
        Keyword,
        Newline,
        EndMarker,
        // ... other token types based on grammar
    }

    public record Token(TokenType Type, string Value);
}