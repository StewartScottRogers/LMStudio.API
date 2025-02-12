namespace PythonLexer.Tokenizer.Tokens
{
    public readonly record struct Token(TokenKind Kind, string Value)
    {
        public static readonly Token EOF = new Token(TokenKind.EndOfFile, "");
    }
}