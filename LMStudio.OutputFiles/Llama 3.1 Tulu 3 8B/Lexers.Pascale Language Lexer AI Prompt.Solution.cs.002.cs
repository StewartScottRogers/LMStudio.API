public class Lexer
{
    private readonly string _input;
    private int _currentIndex;

    public Lexer(string source)
    {
        _input = source;
        _currentIndex = 0;
    }
    
    // Method to get the next character without advancing index.
    private char PeekChar()
    {
        return _currentIndex < _input.Length ? _input[_currentIndex] : '\0';
    }

    // Method to consume characters and emit tokens.
    public IEnumerable<Token> Lex()
    {
        while (_currentIndex < _input.Length)
        {
            var ch = PeekChar();
            switch (ch)
            {
                case 'a' /*... Other letters ...*/: 
                    // Code for consuming identifiers
                    yield return new Token(TokenType.Identifier, ConsumeIdentifier());
                    break;
                case '+': case '-': case '*': case '/':
                    // Code for lexing operators
                    yield return new Token((TokenType)Enum.Parse(typeof(TokenType), ch.ToString()), ch.ToString());
                    break;
                // Handle numbers, strings, and other tokens similarly...
                default:
                    // Handle unknown or whitespace characters.
                    if (Char.IsWhiteSpace(ch))
                        SkipWhitespace();
                    else
                        throw new InvalidOperationException("Unrecognized character: " + ch);
                    break;
            }
        }

        yield return new Token(TokenType.EndOfFile, "");
    }

    private string ConsumeIdentifier()
    {
        var result = "";
        while (Char.IsLetterOrDigit(PeekChar()))
            result += ConsumeCharacter();
        return result;
    }

    // Utility methods for consuming characters and skipping whitespace...
}