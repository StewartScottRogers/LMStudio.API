public readonly struct Token
{
    public static readonly Token EOF = new Token(0, "");
    
    public readonly int Line;
    public readonly string Text;

    public int Type { get; }
    
    public Token(int line, string text)
    {
        Line = line;
        Text = text;
    }

    // Additional token types as needed...
}

public class Lexer
{
    private readonly string _input;
    private int _current = 0;

    public Lexer(string input)
    {
        _input = input;
    }

    public Token NextToken()
    {
        SkipWhitespace();
        
        if (_current >= _input.Length)
            return Token.EOF;

        var c = _input[_current];

        switch (c)
        {
            case '(': yield return new Token(1, "("); break;
            case ')': yield return new Token(2, ")"); break;
            // Add more cases for other tokens...
            default: throw new Exception($"Unexpected character: {c}");
        }

        // Increment current position
        _current++;
    }

    private void SkipWhitespace()
    {
        while (_current < _input.Length && char.IsWhiteSpace(_input[_current]))
            _current++;
    }
}