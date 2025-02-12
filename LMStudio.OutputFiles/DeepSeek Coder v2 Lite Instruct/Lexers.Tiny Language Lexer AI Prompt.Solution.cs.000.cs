using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Lexer
{
    private readonly string _input;
    private int _pos;
    private char _currentChar;

    public Lexer(string input)
    {
        _input = input;
        _pos = 0;
        _currentChar = _input[_pos];
    }

    private void Advance()
    {
        _pos++;
        if (_pos < _input.Length)
            _currentChar = _input[_pos];
        else
            _currentChar = '\0'; // End of input
    }

    private void SkipWhitespace()
    {
        while (_currentChar != '\0' && char.IsWhiteSpace(_currentChar))
        {
            Advance();
        }
    }

    private string Integer()
    {
        var result = "";
        while (_currentChar != '\0' && char.IsDigit(_currentChar))
        {
            result += _currentChar;
            Advance();
        }
        return result;
    }

    private string Id()
    {
        var result = "";
        while (_currentChar != '\0' && (char.IsLetterOrDigit(_currentChar) || _currentChar == '_'))
        {
            result += _currentChar;
            Advance();
        }
        return result;
    }

    public Token GetNextToken()
    {
        while (_currentChar != '\0')
        {
            if (char.IsWhiteSpace(_currentChar))
            {
                SkipWhitespace();
                continue;
            }

            if (char.IsDigit(_currentChar))
            {
                return new Token(TokenTypes.NUMBER, Integer());
            }

            if (char.IsLetter(_currentChar) || _currentChar == '_')
            {
                var text = Id();
                switch (text)
                {
                    case "if":
                        return new Token(TokenTypes.IF, text);
                    case "then":
                        return new Token(TokenTypes.THEN, text);
                    case "while":
                        return new Token(TokenTypes.WHILE, text);
                    case "do":
                        return new Token(TokenTypes.DO, text);
                    case "end":
                        return new Token(TokenTypes.END, text);
                    case "print":
                        return new Token(TokenTypes.PRINT, text);
                    default:
                        return new Token(TokenTypes.ID, text);
                }
            }

            if (_currentChar == ':')
            {
                Advance();
                if (_currentChar == '=')
                {
                    Advance();
                    return new Token(TokenTypes.ASSIGN, ":=");
                }
                throw new SyntaxErrorException("Invalid syntax");
            }

            if (_currentChar == '+')
            {
                Advance();
                return new Token(TokenTypes.PLUS, "+");
            }

            if (_currentChar == '-')
            {
                Advance();
                return new Token(TokenTypes.MINUS, "-");
            }

            if (_currentChar == '*')
            {
                Advance();
                return new Token(TokenTypes.MUL, "*");
            }

            if (_currentChar == '/')
            {
                Advance();
                return new Token(TokenTypes.DIV, "/");
            }

            if (_currentChar == '(')
            {
                Advance();
                return new Token(TokenTypes.LPAREN, "(");
            }

            if (_currentChar == ')')
            {
                Advance();
                return new Token(TokenTypes.RPAREN, ")");
            }

            throw new SyntaxErrorException("Invalid character encountered");
        }

        return new Token(TokenTypes.EOF, null);
    }
}