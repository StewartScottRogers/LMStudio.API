namespace LexerLibrary
{
    public enum TokenType
    {
        Identifier,
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,
        LParen,
        RParen,
        Assign,
        Semicolon,
        If,
        Then,
        End,
        While,
        Do,
        Print
    }

    public class Token
    {
        public readonly TokenType Type;
        public readonly string Value;

        public Token(TokenType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}