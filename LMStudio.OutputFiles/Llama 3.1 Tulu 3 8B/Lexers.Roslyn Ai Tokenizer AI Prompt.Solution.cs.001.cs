// Tokenizer.cs

public class Tokenizer
{
    private static readonly HashSet<char> _whitespaceChars = new() { ' ', '\t', '\r', '\n' };
    // ... other token definitions ...

    public IEnumerable<Token> Tokenize(string sourceCode)
    {
        var tokens = new List<Token>();
        int position = 0;

        while (position < sourceCode.Length)
        {
            if (_whitespaceChars.Contains(sourceCode[position]))
            {
                // Consume whitespace
                while (position < sourceCode.Length && _whitespaceChars.Contains(sourceCode[position]))
                    position++;
                tokens.Add(new Token(TokenType.Whitespace, sourceCode.Substring(position), position));
            }
            else
            {
                // Handle other token types
                // ... implementation ...
            }

            position++;
        }

        return tokens;
    }
}

public class Token
{
    public TokenType Type { get; private set; }
    public string Value { get; private set; }
    public int Position { get; private set; }

    // Constructor and other methods...
}