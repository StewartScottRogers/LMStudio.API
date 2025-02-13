using System.Text.RegularExpressions;

public class Lexer
{
    private readonly string source;
    private int current = 0;
    private int start = 0;
    private int line = 1;
    
    public Lexer(string source)
    {
        this.source = source;
    }

    public Token ScanToken()
    {
        if (IsAtEnd()) return new Token(TokenKind.EndOfFile, "", line);

        char c = Advance();
        switch (c)
        {
            case '=':
                if (Match('='))
                    return new Token(TokenKind.ColonEquals, ":=", line);
                break;
            case '+':
                return new Token(TokenKind.Plus, "+", line);
            case '-':
                return new Token(TokenKind.Minus, "-", line);
            case '*':
                return new Token(TokenKind.Asterisk, "*", line);
            case '/':
                return new Token(TokenKind.Slash, "/", line);
            case '(':
                return new Token(TokenKind.LeftParen, "(", line);
            case ')':
                return new Token(TokenKind.RightParen, ")", line);
            case ';':
                return new Token(TokenKind.Semicolon, ";", line);

            // Ignore whitespace
            case ' ' or '\r' or '\t':
                break;

            // Handle newline
            case '\n':
                line++;
                break;
            
            default:
                if (char.IsDigit(c))
                    return Number();
                else if (char.IsLetter(c))
                    return IdentifierOrKeyword();
                break;
        }

        throw new Exception($"Unexpected character '{c}' at line {line}");
    }
    
    private bool Match(char expected)
    {
        if (IsAtEnd()) return false;
        if (source[current] != expected) return false;

        current++;
        return true;
    }

    private char Advance()
    {
        return source[current++];
    }

    private bool IsAtEnd()
    {
        return current >= source.Length;
    }
    
    private Token IdentifierOrKeyword()
    {
        while (char.IsLetterOrDigit(Peek()))
            Advance();
        
        string text = source.Substring(start, current - start);
        var kind = TokenKind.Identifier;

        switch (text)
        {
            case "if":
                kind = TokenKind.IfKeyword;
                break;
            case "then":
                kind = TokenKind.ThenKeyword;
                break;
            case "while":
                kind = TokenKind.WhileKeyword;
                break;
            case "do":
                kind = TokenKind.DoKeyword;
                break;
            case "end":
                kind = TokenKind.EndKeyword;
                break;
            case "print":
                kind = TokenKind.PrintKeyword;
                break;
        }

        return new Token(kind, text, line);
    }
    
    private Token Number()
    {
        while (char.IsDigit(Peek()))
            Advance();
        
        return new Token(TokenKind.Number, source.Substring(start, current - start), line);
    }
    
    private char Peek()
    {
        if (IsAtEnd()) return '\0';
        return source[current];
    }
}