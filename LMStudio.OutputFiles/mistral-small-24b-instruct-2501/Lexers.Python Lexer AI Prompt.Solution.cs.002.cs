// File: Lexer.cs

using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position;
        private char currentChar;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
            CurrentChar = input[position];
        }

        public (TokenType, object) GetNextToken()
        {
            while (position < input.Length && Char.IsWhiteSpace(currentChar))
            {
                position++;
                currentChar = input[position];
            }
            if (position >= input.Length)
            {
                return (TokenType.EndMarker, null);
            }

            if (char.IsLetter(currentChar) || currentChar == '_')
            {
                var startPosition = position;
                while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
                {
                    position++;
                }
                return new Token(TokenType.Identifier, input.Substring(startPosition, position - startPosition));
            }

            // Add more token definitions as needed based on the grammar

            // Handle other tokens like keywords, operators, etc.

            throw new InvalidOperationException("Unknown character encountered.");
        }

    public void Lex(String sourceCode)
    {
        var tokens = Tokenize(sourceCode);
        foreach (var token in tokens)
        {
            Console.WriteLine(token);
        }
    }
}

public class Token
{
    public string Type { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return $"{Type}: {Value}";
    }
}

public enum TokenType
{
    Name,
    Number,
    String,
    NewLine,
    Indent,
    Dedent,
    EndMarker,
    // Add other token types as needed based on the grammar
}

public class Lexer
{
    private readonly string Input;
    private int Position;

    public Lexer(string input)
    {
        this.Input = input;
        this.Position = 0;
    }

    public List<(TokenType Token, string Value)> Tokenize()
    {
        var tokens = new List<(TokenType Token, string Value)>();
        while (this.Position < this.Input.Length)
        {
            if (char.IsWhiteSpace(this.Input[this.Position]))
            {
                this.Position++;
                continue;
            }

            // Implement token matching logic here
            // This is a placeholder for the actual lexing logic

            var matchedToken = new Token();
            // Populate matchedToken with the appropriate values based on the input

            yield return matchedToken;
        }
    }
}