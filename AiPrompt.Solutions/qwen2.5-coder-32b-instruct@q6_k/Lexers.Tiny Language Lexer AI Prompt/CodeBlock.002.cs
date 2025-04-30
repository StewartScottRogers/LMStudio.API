using System.Text;

public class Lexer
{
    private readonly string Source;
    private int Current = 0;
    private int Line = 1;

    public Lexer(string source)
    {
        Source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public Token NextToken()
    {
        SkipWhitespace();
        if (IsAtEnd())
            return new Token(TokenType.Eof, string.Empty);

        char c = Advance();

        switch (c)
        {
            case '=': 
                return Match('=') ? new Token(TokenType.Assign, ":=") : throw new Exception("Invalid token");
            case '+': 
                return new Token(TokenType.Plus, "+");
            case '-': 
                return new Token(TokenType.Minus, "-");
            case '*': 
                return new Token(TokenType.Asterisk, "*");
            case '/': 
                return new Token(TokenType.Slash, "/");
            case '(': 
                return new Token(TokenType.LeftParen, "(");
            case ')': 
                return new Token(TokenType.RightParen, ")");
            case ';': 
                return new Token(TokenType.Semicolon, ";");

            default:
                if (char.IsDigit(c))
                    return Number();
                else if (char.IsLetter(c))
                    return Identifier();

                throw new Exception($"Unexpected character '{c}'");
        }
    }

    private void SkipWhitespace()
    {
        while (Current < Source.Length && char.IsWhiteSpace(Source[Current]))
        {
            if (Source[Current] == '\n')
                Line++;

            Current++;
        }
    }

    private bool IsAtEnd() => Current >= Source.Length;

    private char Advance()
    {
        Current++;
        return Source[Current - 1];
    }

    private bool Match(char expected)
    {
        if (IsAtEnd()) 
            return false;
        if (Source[Current] != expected) 
            return false;

        Current++;
        return true;
    }

    private Token Number()
    {
        while (Current < Source.Length && char.IsDigit(Source[Current]))
            Advance();

        var numberString = Source.Substring(Current - (Current - 1), (Current - 1));
        return new Token(TokenType.Number, numberString);
    }

    private Token Identifier()
    {
        while (Current < Source.Length && char.IsLetterOrDigit(Source[Current]))
            Advance();

        var identifierString = Source.Substring(Current - (Current - 1), (Current - 1));
        switch (identifierString.ToLower())
        {
            case "if": 
                return new Token(TokenType.If, identifierString);
            case "then": 
                return new Token(TokenType.Then, identifierString);
            case "while": 
                return new Token(TokenType.While, identifierString);
            case "do": 
                return new Token(TokenType.Do, identifierString);
            case "print": 
                return new Token(TokenType.Print, identifierString);
            case "end": 
                return new Token(TokenType.End, identifierString);

            default:
                return new Token(TokenType.Identifier, identifierString);
        }
    }
}