using System;
using System.Collections.Generic;
using System.IO;

public class Lexer
{
    private readonly string sourceCode;
    private int current = 0;
    private int start = 0;
    private int line = 1;

    public Lexer(string sourceCode)
    {
        this.sourceCode = sourceCode;
    }

    public IEnumerable<Token> Lex()
    {
        while (!IsAtEnd())
        {
            start = current;
            Token token = ScanToken();
            if (token != null)
                yield return token;
        }
    }

    private bool IsAtEnd()
    {
        return current >= sourceCode.Length;
    }

    private char PeekNext()
    {
        return current + 1 < sourceCode.Length ? sourceCode[current + 1] : '\0';
    }

    private Token ScanToken()
    {
        char c = Advance();
        switch (c)
        {
            case '+': return new Token(TokenTypes.Plus, "+");
            case '-': return new Token(TokenTypes.Minus, "-");
            case '*': return new Token(TokenTypes.Asterisk, "*");
            case '/': return new Token(TokenTypes.Slash, "/");
            case '(': return new Token(TokenTypes.LeftParenthesis, "(");
            case ')': return new Token(TokenTypes.RightParenthesis, ")");
            case ';': return new Token(TokenTypes.Semicolon, ";");

            case '=':
                if (Match('='))
                    return new Token(TokenTypes.Equal, "==");
                else
                    throw new ArgumentException("Unexpected character");

            case 'i':
                if (Match('f'))
                    return new Token(TokenTypes.If, "if");
                else
                    return IdentifierOrKeyword();
            case 't':
                if (Match('h') && Match('e') && Match('n'))
                    return new Token(TokenTypes.Then, "then");
                else
                    return IdentifierOrKeyword();
            case 'w':
                if (Match('h') && Match('i') && Match('l') && Match('e'))
                    return new Token(TokenTypes.While, "while");
                else
                    return IdentifierOrKeyword();
            case 'd':
                if (Match('o'))
                    return new Token(TokenTypes.Do, "do");
                else
                    return IdentifierOrKeyword();
            case 'p':
                if (Match('r') && Match('i') && Match('n') && Match('t'))
                    return new Token(TokenTypes.Print, "print");
                else
                    return IdentifierOrKeyword();
            case 'e':
                if (Match('n') && Match('d'))
                    return new Token(TokenTypes.End, "end");
                else
                    return IdentifierOrKeyword();

            case ' ':
            case '\r':
            case '\t': break;
            case '\n':
                line++;
                break;

            default:
                if (IsDigit(c))
                    return Number();
                if (IsAlpha(c))
                    return IdentifierOrKeyword();
                throw new ArgumentException($"Unexpected character {c}");
        }
        return null;
    }

    private bool Match(char expected)
    {
        if (IsAtEnd())
            return false;
        if (sourceCode[current] != expected)
            return false;

        current++;
        return true;
    }

    private Token Number()
    {
        while (IsDigit(Peek()))
            Advance();

        string value = sourceCode.Substring(start, current - start);
        return new Token(TokenTypes.Number, value);
    }

    private bool IsDigit(char c)
    {
        return c >= '0' && c <= '9';
    }

    private char Advance()
    {
        if (!IsAtEnd())
            current++;
        return sourceCode[current - 1];
    }

    private char Peek()
    {
        return IsAtEnd() ? '\0' : sourceCode[current];
    }

    private bool IsAlpha(char c)
    {
        return (c >= 'a' && c <= 'z') ||
               (c >= 'A' && c <= 'Z');
    }

    private Token IdentifierOrKeyword()
    {
        while (IsAlphaNumeric(Peek()))
            Advance();

        string text = sourceCode.Substring(start, current - start);
        return new Token(TokenTypes.Identifier, text);
    }

    private bool IsAlphaNumeric(char c)
    {
        return IsAlpha(c) || IsDigit(c);
    }
}