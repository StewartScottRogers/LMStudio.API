using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer : ILexer
    {
        private readonly string input;

        // Constructor for the lexer.
        public Lexer(string input)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public IReadOnlyList<Token> Tokenize()
        {
            var tokens = new List<Token>();
            var position = 0;
            while (position < input.Length)
            {
                var currentChar = input[position];
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }

                if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
                {
                    var token = ReadIdentifier(position);
                    position += token.Length;
                    // Handle identifier token
                }
                else if (char.IsPunctuation(currentChar))
                {
                    var token = ReadPunctuationToken(position);
                    position += token.Length;
                    // Handle punctuation token
                }
                else
                {
                    throw new InvalidOperationException("Unexpected character");
                }

Let's break down the steps to create a .NET 9.0 solution that meets all the requirements outlined in your prompt.

### Step 1: Initialize a New Solution

1. Open Visual Studio 2022.
2. Create a new Class Library project targeting .NET 9.0.
3. Name the solution `LexerLibrary`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as specified.

#### File: Lexer.cs