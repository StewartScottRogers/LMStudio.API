using System;
using System.Collections.Generic;
using System.Linq;

public class Lexer
{
    private readonly string sourceCode;
    private int current = 0;
    private List<Token> tokens = new List<Token>();

    public Lexer(string source)
    {
        sourceCode = source;
    }

    public List<Token> ScanTokens()
    {
        while (!IsAtEnd())
        {
            char character = Advance();
            switch (character)
            {
                case ';':
                    AddToken(TokenType.Semicolon);
                    break;
                case '(':
                    AddToken(TokenType.LeftParenthesis);
                    break;
                case ')':
                    AddToken(TokenType.RightParenthesis);
                    break;
                case '+':
                    AddToken(TokenType.Plus);
                    break;
                case '-':
                    AddToken(TokenType.Minus);
                    break;
                case '*':
                    AddToken(TokenType.Star);
                    break;
                case '/':
                    AddToken(TokenType.Slash);
                    break;
                case 'i' when Match("f"):
                    AddToken(TokenType.If);
                    break;
                case 't' when Match("hen"):
                    AddToken(TokenType.Then);
                    break;
                case 'e' when Match("nd"):
                    AddToken(TokenType.End);
                    break;
                case 'w' when Match("hile"):
                    AddToken(TokenType.While);
                    break;
                case 'd' when Match("o"):
                    AddToken(TokenType.Do);
                    break;
                case 'p' when Match("rint"):
                    AddToken(TokenType.Print);
                    break;
                case char c when IsAlpha(c):
                    string identifier = Identifier();
                    switch (identifier)
                    {
                        // Handle more keywords if needed
                    }
                    AddToken(TokenType.Identifier, identifier);
                    break;
                case char d when IsDigit(d):
                    number = Number();
                    AddToken(TokenType.Number, number);
                    break;
                default:
                    Console.WriteLine($"Unexpected character: {character}");
                    break;
            }

            SkipWhitespace();
        }

        tokens.Add(new Token(TokenType.Eof, string.Empty));
        return tokens;
    }

    private char Advance()
    {
        current++;
        return sourceCode[current - 1];
    }

    private void AddToken(TokenType type)
    {
        var text = sourceCode.Substring(current - 1, 1);
        tokens.Add(new Token(type, text));
    }

    private void AddToken(TokenType type, string literal)
    {
        var text = sourceCode.Substring(current - literal.Length, literal.Length);
        tokens.Add(new Token(type, text, literal));
    }

    private bool IsAtEnd() => current >= sourceCode.Length;

    private char Peek()
    {
        if (IsAtEnd()) return '\0';
        return sourceCode[current];
    }

    private char PeekNext()
    {
        if (current + 1 >= sourceCode.Length) return '\0';
        return sourceCode[current + 1];
    }

    private bool Match(char expected)
    {
        if (IsAtEnd() || sourceCode[current] != expected) return false;
        current++;
        return true;
    }

    private void SkipWhitespace()
    {
        while (!IsAtEnd())
        {
            char c = Peek();
            switch (c)
            {
                case ' ':
                case '\r':
                case '\t':
                    Advance();
                    break;
                case '\n':
                    Advance();
                    break;
                default:
                    return;
            }
        }
    }

    private string Identifier()
    {
        while (IsAlphaNumeric(Peek())) Advance();
        return sourceCode.Substring(current - 1, current - (current - 1));
    }

    private string Number()
    {
        while (IsDigit(Peek())) Advance();

        if (Peek() == '.' && IsDigit(PeekNext()))
        {
            Advance();
            while (IsDigit(Peek())) Advance();
        }
        return sourceCode.Substring(current - 1, current - (current - 1));
    }

    private bool IsAlpha(char c) => char.IsLetter(c);
    private bool IsDigit(char c) => char.IsDigit(c);
    private bool IsAlphaNumeric(char c) => IsAlpha(c) || IsDigit(c);

    private readonly string number;
}