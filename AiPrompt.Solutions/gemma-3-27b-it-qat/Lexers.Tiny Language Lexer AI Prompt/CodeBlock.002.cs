using System;
using System.Collections.Generic;

namespace LexerLibrary;

public class Lexer
{
    private readonly string _inputString;
    private int _position;

    public Lexer(string inputString)
    {
        _inputString = inputString;
        _position = 0;
    }

    public (Token Token, string RemainingInput) GetNextToken()
    {
        if (_position >= _inputString.Length)
        {
            return (new Token(TokenType.EndOfFile, ""), "");
        }

        char currentChar = _inputString[_position];

        // Skip whitespace
        while (char.IsWhiteSpace(currentChar))
        {
            _position++;
            if (_position >= _inputString.Length)
            {
                return (new Token(TokenType.EndOfFile, ""), "");
            }
            currentChar = _inputString[_position];
        }

        if (char.IsLetter(currentChar))
        {
            string identifier = ReadIdentifier();
            return (new Token(TokenType.Identifier, identifier), RemainingInput);
        }
        else if (char.IsDigit(currentChar))
        {
            string number = ReadNumber();
            return (new Token(TokenType.Number, number), RemainingInput);
        }

        switch (currentChar)
        {
            case '+':
                _position++;
                return (new Token(TokenType.Plus, "+"), RemainingInput);
            case '-':
                _position++;
                return (new Token(TokenType.Minus, "-"), RemainingInput);
            case '*':
                _position++;
                return (new Token(TokenType.Multiply, "*"), RemainingInput);
            case '/':
                _position++;
                return (new Token(TokenType.Divide, "/"), RemainingInput);
            case ':':
                if (_position + 1 < _inputString.Length && _inputString[_position + 1] == '=')
                {
                    _position += 2;
                    return (new Token(TokenType.Assign, ":="), RemainingInput);
                }
                else
                {
                    // Handle single ':' as an error or unexpected character
                    throw new ArgumentException($"Unexpected character ':'.");
                }
            case ';':
                _position++;
                return (new Token(TokenType.Semicolon, ";"), RemainingInput);
            case '(':
                _position++;
                return (new Token(TokenType.LeftParen, "("), RemainingInput);
            case ')':
                _position++;
                return (new Token(TokenType.RightParen, ")"), RemainingInput);
            default:
                throw new ArgumentException($"Unexpected character '{currentChar}'.");
        }
    }

    private string ReadIdentifier()
    {
        int startPosition = _position;
        while (_position < _inputString.Length && (char.IsLetter(_inputString[_position]) || char.IsDigit(_inputString[_position])))
        {
            _position++;
        }
        return _inputString.Substring(startPosition, _position - startPosition);
    }

    private string ReadNumber()
    {
        int startPosition = _position;
        while (_position < _inputString.Length && char.IsDigit(_inputString[_position]))
        {
            _position++;
        }
        return _inputString.Substring(startPosition, _position - startPosition);
    }

    public string RemainingInput => _inputString.Substring(_position);
}