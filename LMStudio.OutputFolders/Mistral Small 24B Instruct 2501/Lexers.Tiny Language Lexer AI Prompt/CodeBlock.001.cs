// File: Token.cs
namespace LexerLibrary.Lexer
{
    public record Token(TokenType Type, string Value)
    {
        public Token(TokenType type, string value) : this()
        {
            Type = type;
            Value = value;
        }
    }
}