// Lexer.cs
public class Lexer
{
    private readonly string sourceCode;
    private int currentPosition;

    public Lexer(string sourceCode)
    {
        this.sourceCode = sourceCode;
        currentPosition = 0;
    }

    private char Peek()
    {
        if (currentPosition < sourceCode.Length)
        {
            return sourceCode[currentPosition];
        }
        else
        {
            return '\0'; // End of file
        }
    }

    private void Advance()
    {
        currentPosition++;
    }

    public (TokenTuple, bool) GetNextToken()
    {
        while (Peek() != '\0' && Peek() == ' ')
        {
            Advance(); // Skip whitespace
        }

        if (currentPosition >= sourceCode.Length)
        {
            return (new TokenTuple(TokenType.EndOfFile, ""), false);
        }

        char currentChar = Peek();

        if (char.IsLetter(currentChar))
        {
            string identifier = "";
            while (char.IsLetterOrDigit(Peek()))
            {
                identifier += Peek();
                Advance();
            }
            return (new TokenTuple(TokenType.Identifier, identifier), true);
        }
        else if (char.IsDigit(currentChar))
        {
            string number = "";
            while (char.IsDigit(Peek()))
            {
                number += Peek();
                Advance();
            }
            return (new TokenTuple(TokenType.Number, number), true);
        }
        else
        {
            switch (currentChar)
            {
                case '+': Advance(); return (new TokenTuple(TokenType.Plus, "+"), true);
                case '-': Advance(); return (new TokenTuple(TokenType.Minus, "-"), true);
                case '*': Advance(); return (new TokenTuple(TokenType.Multiply, "*"), true);
                case '/': Advance(); return (new TokenTuple(TokenType.Divide, "/"), true);
                case ':':
                    Advance();
                    if (Peek() == '=')
                    {
                        Advance();
                        return (new TokenTuple(TokenType.Assign, ":="), true);
                    }
                    else
                    {
                        // Handle invalid input if needed
                        return (new TokenTuple(TokenType.Identifier, ":"), true); // Or throw an exception
                    }
                case ';': Advance(); return (new TokenTuple(TokenType.Semicolon, ";"), true);
                case '(': Advance(); return (new TokenTuple(TokenType.LeftParen, "("), true);
                case ')': Advance(); return (new TokenTuple(TokenType.RightParen, ")"), true);
                case 'i':
                    if (sourceCode.Substring(currentPosition, 3) == "if")
                    {
                        Advance(); Advance(); Advance();
                        return (new TokenTuple(TokenType.If, "if"), true);
                    }
                    break;
                case 't':
                    if (sourceCode.Substring(currentPosition, 4) == "then")
                    {
                        Advance(); Advance(); Advance(); Advance();
                        return (new TokenTuple(TokenType.Then, "then"), true);
                    }
                    break;
                case 'e':
                    if (sourceCode.Substring(currentPosition, 3) == "end")
                    {
                        Advance(); Advance(); Advance();
                        return (new TokenTuple(TokenType.End, "end"), true);
                    }
                    break;
                case 'w':
                    if (sourceCode.Substring(currentPosition, 5) == "while")
                    {
                        Advance(); Advance(); Advance(); Advance(); Advance();
                        return (new TokenTuple(TokenType.While, "while"), true);
                    }
                    break;
                case 'd':
                    if (sourceCode.Substring(currentPosition, 2) == "do")
                    {
                        Advance(); Advance();
                        return (new TokenTuple(TokenType.Do, "do"), true);
                    }
                    break;
                case 'p':
                    if (sourceCode.Substring(currentPosition, 5) == "print")
                    {
                        Advance(); Advance(); Advance(); Advance(); Advance();
                        return (new TokenTuple(TokenType.Print, "print"), true);
                    }
                    break;

            }
        }

        // Handle invalid characters or unexpected input if needed
        return (new TokenTuple(TokenType.Identifier, currentChar.ToString()), true); // Or throw an exception
    }
}