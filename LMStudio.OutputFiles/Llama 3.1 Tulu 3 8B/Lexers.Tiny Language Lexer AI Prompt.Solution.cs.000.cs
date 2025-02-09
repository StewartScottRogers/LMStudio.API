using System;
using System.Collections.Generic;

public class Token
{
    public TokenType Type { get; set; }
    public string Value { get; set; }

    enum TokenType
    {
        Identifier,
        Number,
        Plus,
        Minus,
        Star,
        Slash,
        LParen,
        RParen,
        ColonEqual,
        If,
        Then,
        End,
        While,
        Do,
        Print,
        // Add more token types as needed
    }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}

public class Lexer
{
    private readonly string _source;
    private int _currentPosition;

    public Lexer(string source)
    {
        _source = source;
        _currentPosition = 0;
    }

    public IEnumerable<Token> Lex()
    {
        while (_currentPosition < _source.Length)
        {
            // Implement tokenization logic here
            var c = _source[_currentPosition];
            
            if (Char.IsLetter(c))
            {
                var identifier = ScanIdentifier();
                yield return new Token(TokenType.Identifier, identifier);
            }
            else if (Char.IsDigit(c))
            {
                var number = ScanNumber();
                yield return new Token(TokenType.Number, number);
            }
            else if ("+ - * / ()".Contains(c.ToString()))
            {
                // Process operators and parentheses
                yield return new Token(Enum.Parse<TokenType>(c.ToString()), c.ToString());
            }
            // Continue for other tokens like ":", "if", "then", etc.

            _currentPosition++;
        }
    }

    private string ScanIdentifier()
    {
        var builder = new StringBuilder();
        while (_currentPosition < _source.Length && Char.IsLetterOrDigit(_source[_currentPosition]))
        {
            builder.Append(_source[_currentPosition]);
            _currentPosition++;
        }
        return builder.ToString();
    }

    private string ScanNumber()
    {
        var numberBuilder = new StringBuilder();
        while (_currentPosition < _source.Length && Char.IsDigit(_source[_currentPosition]))
        {
            numberBuilder.Append(_source[_currentPosition]);
            _currentPosition++;
        }
        return numberBuilder.ToString();
    }
}