using System;
using System.Collections.Generic;
using System.IO;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position;
        private int lineNumber;
        private int columnNumber;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
            this.lineNumber = 1;
            this.columnNumber = 1;
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();
            while (position < input.Length)
            {
                char currentChar = input[position];
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }
                else
                {
                    // Tokenization logic goes here.
                    // For simplicity, we'll just identify some basic tokens.
                    if(char.IsDigit(currentChar) || currentChar == '.')
                    {
                        // Number token
                        var numberToken = ParseNumber(input);
                    }
                    else if (char.IsLetter(currentChar))
                    {
                        // Identifier or keyword token
                        var identifierOrKeywordToken = ParseIdentifierOrKeyword(input);
                    }
                    else if (char.Equals('=') || char.Equals('+') || char.Equals('-') || char.Equals('*') ||
                             char.Equals('/') || char.Equals('%') || char.Equals('&') || char.Equals('|') ||
                             char.Equals('^') || char.Equals('<') || char.Equals('>') || char.Equals('='))  # Must be followed by indented block