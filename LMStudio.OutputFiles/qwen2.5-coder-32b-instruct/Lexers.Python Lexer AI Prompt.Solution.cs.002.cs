using System.IO;
using System.Text.RegularExpressions;

public class Lexer
{
    private readonly string input;
    private int position = 0;
    private char currentChar;

    public Lexer(string input)
    {
        this.input = input;
        this.currentChar = input[position];
    }

    private void Advance()
    {
        position++;
        if (position >= input.Length) currentChar = '\0'; // End of input
        else currentChar = input[position];
    }

    private string ReadNameOrKeyword()
    {
        var result = "";
        while (char.IsLetter(currentChar) || char.IsDigit(currentChar) || currentChar == '_')
        {
            result += currentChar;
            Advance();
        }
        return result;
    }

    public Token GetNextToken()
    {
        while (currentChar != '\0')
        {
            if (char.IsWhiteSpace(currentChar))
            {
                SkipWhitespace();
                continue;
            }

            if (char.IsLetter(currentChar) || currentChar == '_')
            {
                var nameOrKeyword = ReadNameOrKeyword();
                switch (nameOrKeyword)
                {
                    case "return":
                    case "raise":
                    case "global":
                    case "nonlocal":
                    case "del":
                    case "yield":
                    case "assert":
                    case "import":
                    case "class":
                    case "def":
                    case "if":
                    case "elif":
                    case "else":
                    case "while":
                    case "for":
                    case "with":
                    case "try":
                    case "except":
                    case "finally":
                    case "match":
                        return new Token(TokenType.Keyword, nameOrKeyword);
                    default:
                        return new Token(TokenType.Name, nameOrKeyword);
                }
            }

            if (char.IsDigit(currentChar))
            {
                return new Token(TokenType.Number, ReadNumber());
            }

            if (currentChar == '\"' || currentChar == '\'')
            {
                return new Token(TokenType.String, ReadString());
            }

            // Handle operators and punctuation
            switch (currentChar)
            {
                case '=':
                    Advance();
                    if (currentChar == '=') { Advance(); return new Token(TokenType.Operator, "=="); }
                    else if (currentChar == '>') { Advance(); return new Token(TokenType.Operator, "=>"); }
                    else return new Token(TokenType.Punctuation, "=");
                // Add more operators and punctuation here
                default:
                    var token = new Token(TokenType.Punctuation, currentChar.ToString());
                    Advance();
                    return token;
            }
        }

        return new Token(TokenType.EndMarker, "");
    }

    private void SkipWhitespace()
    {
        while (currentChar != '\0' && char.IsWhiteSpace(currentChar))
            Advance();
    }

    private string ReadNumber()
    {
        var result = "";
        while (char.IsDigit(currentChar))
        {
            result += currentChar;
            Advance();
        }
        return result;
    }

    private string ReadString()
    {
        var quoteType = currentChar;
        var result = "";
        Advance(); // Skip the opening quote
        while (currentChar != '\0' && currentChar != quoteType)
        {
            result += currentChar;
            Advance();
        }
        Advance(); // Skip the closing quote
        return result;
    }
}