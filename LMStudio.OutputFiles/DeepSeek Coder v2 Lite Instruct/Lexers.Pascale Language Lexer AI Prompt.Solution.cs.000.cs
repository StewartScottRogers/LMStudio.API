public enum TokenType {
    Identifier, Number, String, // Add other types as needed
    // ... more token types
}

public struct Token {
    public TokenType Type { get; }
    public string Lexeme { get; }
    public object Literal { get; }

    public Token(TokenType type, string lexeme, object literal) {
        Type = type;
        Lexeme = lexeme;
        Literal = literal;
    }
}