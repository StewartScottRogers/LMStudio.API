public record Token(TokenTuple);

public readonly struct TokenTuple
{
    public TokenType Type { get; }
    public string Value { get; }

    public TokenTuple(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}

public class Lexer : ILexer
{
    private readonly string _sourceCode;

    public Lexer(string sourceCode)
    {
        _sourceCode = sourceCode.Trim();
    }

    public IEnumerable<Token> Tokenize()
    {
        // Logic for tokenizing the input
    }
}