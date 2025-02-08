public class Lexer
{
    private readonly string Source;
    private int Position;
    private char CurrentChar;

    public Lexer(string source)
    {
        Source = source;
        Position = 0;
        CurrentChar = Source[Position];
    }

    private void Advance()
    {
        Position++;
        if (Position > Source.Length - 1) 
            CurrentChar = '\0'; // End of file
        else 
            CurrentChar = Source[Position];
    }
    
    private void SkipWhitespace()
    {
        while (CurrentChar is >= ' ' and <= '\r') Advance();
    }

    private Token Identifier()
    {
        string result = "";
        while (char.IsLetterOrDigit(CurrentChar)) 
        {
            result += CurrentChar;
            Advance();
        }
        return new Token(TokenType.Identifier, result);
    }

    public Token GetNextToken()
    {
        SkipWhitespace();

        if (Position >= Source.Length) 
            return new Token(TokenType.Eof, "");

        char currentChar = CurrentChar;

        if (char.IsLetter(currentChar))
            return Identifier();
        
        // Add handling for other characters and keywords
        throw new InvalidOperationException("Unknown character: " + currentChar);
    }
}