using System;
using System.Collections.Generic;

public class Lexer
{
    private readonly string _source;
    private int _position;
    private int _readPosition;
    private char _currentChar;

    public Lexer(string source)
    {
        _source = source;
        ReadChar();
    }

    private void ReadChar()
    {
        if (_readPosition >= _source.Length)
            _currentChar = (char)0; // ASCII NUL
        else
            _currentChar = _source[_readPosition];
        _position = _readPosition;
        _readPosition++;
    }

    private char PeekChar()
    {
        return _readPosition >= _source.Length ? (char)0 : _source[_readPosition];
    }

    public Token NextToken()
    {
        SkipWhitespace();

        var ch = _currentChar;

        switch (ch)
        {
            case '=':
                ReadChar();
                if (_currentChar == '=')
                    return new(Token.Equal, "==");
                return new(Token.Assign, "=");
            case '+':
                ReadChar();
                return new(Token.Plus, "+");
            case '-':
                ReadChar();
                return new(Token.Minus, "-");
            case '*':
                ReadChar();
                return new(Token.Multiply, "*");
            case '/':
                ReadChar();
                return new(Token.Divide, "/");
            case '(':
                ReadChar();
                return new(Token.LeftParenthesis, "(");
            case ')':
                ReadChar();
                return new(Token.RightParenthesis, ")");
            case ';':
                ReadChar();
                return new(Token.Semicolon, ";");
            case (char)0:
                return new(Token.EOF, null);
        }

        if (IsLetter(ch))
        {
            var literal = ReadIdentifier();
            switch (literal.ToLower())
            {
                case "if":
                    return new(TokenType.If, "if");
                case "then":
                    return new(TokenType.Then, "then");
                case "while":
                    return new(TokenType.While, "while");
                case "do":
                    return new(TokenType.Do, "do");
                case "end":
                    return new(TokenType.End, "end");
                case "print":
                    return new(TokenType.Print, "print");
            }
            return new(TokenType.Identifier, literal);
        }

        if (IsDigit(ch))
        {
            var number = ReadNumber();
            return new(Token.Number, number);
        }

        throw new Exception($"Unknown character: {ch}");
    }

    private void SkipWhitespace()
    {
        while (_currentChar == ' ' || _currentChar == '\t' || _currentChar == '\n' || _currentChar == '\r')
        {
            ReadChar();
        }
    }

    private string ReadIdentifier()
    {
        var position = _position;
        while (IsLetter(_currentChar) || IsDigit(_currentChar))
        {
            ReadChar();
        }

        return _source[position.._position];
    }

    private string ReadNumber()
    {
        var position = _position;
        while (IsDigit(_currentChar))
        {
            ReadChar();
        }
        return _source[position.._position];
    }

    private bool IsLetter(char ch)
    {
        return ('a' <= ch && ch <= 'z') || ('A' <= ch && ch <= 'Z');
    }

    private bool IsDigit(char ch)
    {
        return '0' <= ch && ch <= '9';
    }
}