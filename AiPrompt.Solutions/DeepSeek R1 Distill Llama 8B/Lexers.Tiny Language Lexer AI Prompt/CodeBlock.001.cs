using System.Text;

public class Lexer
{
    private readonly string source;
    private int position = 0;
    private int readPosition = 0;
    private char currentChar;

    public Lexer(string input)
    {
        source = input;
        ReadChar();
    }

    private void ReadChar()
    {
        if (readPosition >= source.Length)
            currentChar = '\0';
        else
            currentChar = source[readPosition];
        
        position = readPosition;
        readPosition++;
    }

    public Token NextToken()
    {
        SkipWhitespace();

        Token token;

        switch (currentChar)
        {
            case '=':
                if (PeekChar() == '=')
                {
                    ReadChar();
                    token = new Token(TokenType.ColonEquals, ":=");
                }
                else
                {
                    token = new Token(TokenType.Assign, "=");
                }
                break;
            case ';':
                token = new Token(TokenType.Semicolon, ";");
                break;
            case '+':
                token = new Token(TokenType.Plus, "+");
                break;
            case '-':
                token = new Token(TokenType.Minus, "-");
                break;
            case '*':
                token = new Token(TokenType.Multiply, "*");
                break;
            case '/':
                token = new Token(TokenType.Divide, "/");
                break;
            case '(':
                token = new Token(TokenType.LeftParenthesis, "(");
                break;
            case ')':
                token = new Token(TokenType.RightParenthesis, ")");
                break;
            case '\0':
                token = new Token(TokenType.EndOfFile, "");
                break;
            default:
                if (char.IsLetter(currentChar))
                    return ReadIdentifier();
                else if (char.IsDigit(currentChar))
                    return ReadNumber();
                else
                    token = new Token(TokenType.Illegal, currentChar.ToString());
                break;
        }

        ReadChar();

        return token;
    }

    private void SkipWhitespace()
    {
        while (currentChar is ' ' or '\t' or '\n' or '\r')
            ReadChar();
    }

    private char PeekChar() => readPosition >= source.Length ? '\0' : source[readPosition];

    private Token ReadIdentifier()
    {
        int startPos = position;
        
        while (char.IsLetterOrDigit(currentChar))
            ReadChar();

        string identifier = source.Substring(startPos, position - startPos);
        
        return new Token(LookupIdent(identifier), identifier);
    }

    private static TokenType LookupIdent(string ident)
    {
        switch (ident.ToLower())
        {
            case "if":
                return TokenType.IfKeyword;
            case "then":
                return TokenType.ThenKeyword;
            case "while":
                return TokenType.WhileKeyword;
            case "do":
                return TokenType.DoKeyword;
            case "print":
                return TokenType.PrintKeyword;
            case "end":
                return TokenType.EndKeyword;
            default:
                return TokenType.Identifier;
        }
    }

    private Token ReadNumber()
    {
        int startPos = position;

        while (char.IsDigit(currentChar))
            ReadChar();

        string number = source.Substring(startPos, position - startPos);

        return new Token(TokenType.Number, number);
    }
}