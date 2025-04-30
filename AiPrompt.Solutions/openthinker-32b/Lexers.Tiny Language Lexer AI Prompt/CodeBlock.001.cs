public class Token
{
    public TokenType Type { get; }
    public string Lexeme { get; }
    public object Literal { get; }

    public Token(TokenType type, string lexeme)
    {
        Type = type;
        Lexeme = lexeme;
        Literal = null;
    }

    public Token(TokenType type, string lexeme, object literal)
    {
        Type = type;
        Lexeme = lexeme;
        Literal = literal;
    }
}