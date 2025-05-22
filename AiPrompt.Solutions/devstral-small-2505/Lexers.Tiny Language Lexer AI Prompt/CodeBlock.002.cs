using System;
using System.Collections.Generic;

public class Lexer
{
    private readonly string input;
    private int position = 0;
    private char currentChar;

    public Lexer(string input)
    {
        this.input = input;
        this.currentChar = (position < input.Length) ? input[position] : '\0';
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

            if (char.IsLetter(currentChar))
            {
                return new Token(TokenType.Identifier, Identifier());
            }

            if (char.IsDigit(currentChar))
            {
                return new Token(TokenType.Number, Number());
            }

            switch (currentChar)
            {
                case ':':
                    NextChar();
                    if (currentChar == '=') { NextChar(); return new Token(TokenType.Assign, ":"); }
                    throw new LexerException("Invalid symbol sequence");
                case '+': NextChar(); return new Token(TokenType.Plus, "+");
                case '-': NextChar(); return new Token(TokenType.Minus, "-");
                case '*': NextChar(); return new Token(TokenType.Multiply, "*");
                case '/': NextChar(); return new Token(TokenType.Divide, "/");
                case '(': NextChar(); return new Token(TokenType.LParen, "(");
                case ')': NextChar(); return new Token(TokenType.RParen, ")");
                case ';': NextChar(); return new Token(TokenType.Semicolon, ";");
            }

            throw new LexerException($"Invalid character: {currentChar}");
        }
        return new Token(TokenType.Eof, "");
    }

    private string Identifier()
    {
        var identifier = "";
        while (char.IsLetterOrDigit(currentChar))
        {
            identifier += currentChar;
            NextChar();
        }
        return identifier;
    }

    private string Number()
    {
        var number = "";
        while (char.IsDigit(currentChar))
        {
            number += currentChar;
            NextChar();
        }
        return number;
    }

    private void SkipWhitespace()
    {
        while (char.IsWhiteSpace(currentChar))
        {
            NextChar();
        }
    }

    private void NextChar()
    {
        position++;
        currentChar = (position < input.Length) ? input[position] : '\0';
    }
}

public class Token
{
    public TokenType Type { get; }
    public string Value { get; }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}