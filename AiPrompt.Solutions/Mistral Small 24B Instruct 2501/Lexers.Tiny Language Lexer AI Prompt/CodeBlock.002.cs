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
            this.currentChar = input[position];
        }

        private void Advance()
        {
            position++;
            if (position >= input.Length)
            {
                currentChar = '\0'; // End of file
            }
            else
            {
                currentChar = input[position];
            }
        }

        private void SkipWhitespace()
        {
            while (currentChar != '\0' && char.IsWhiteSpace(currentChar))
            {
                Advance();
            }
        }

        private Token Number()
        {
            var value = "";
            while (currentChar != '\0' && char.IsDigit(currentChar))
            {
                value += currentChar;
                Advance();
            }
            return new Token(TokenKind.Number, value);
        }

        private bool IsLetter(char c) => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');

        private Token Id()
        {
            var value = "";
            while (currentChar != '\0' && (IsLetter(currentChar) || char.IsDigit(currentChar)))
            {
                value += currentChar;
                Advance();
            }

            if (value == "if")
                return new Token(TokenKind.If, value);
            else if (value == "then")
                return new Token(TokenKind.Then, value);
            else if (value == "while")
                return new Token(TokenKind.While, value);
            else if (value == "do")
                return new Token(TokenKind.Do, value);
            else if (value == "print")
                return new Token(TokenKind.Print, value);

            return new Token(TokenKind.Id, value);
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
                else if (IsLetter(currentChar))
                {
                    return Id();
                }
                else if (char.IsDigit(currentChar))
                {
                    return Number();
                }

                var tokenKind = currentChar switch
                {
                    ':'
                        when Peek() == '=' =>
                    {
                        Advance();
                        Advance(); // skip :=
                        yield return new Token(TokenKind.Assign, ":=");
                    },
                    '+' => TokenKind.Plus,
                    '-' => TokenKind.Minus,
                    '*' => TokenKind.Star,
                    '/' => TokenKind.Slash,
                    '(' => TokenKind.LeftParen,
                    ')' => TokenKind.RightParen,
                    ';' => TokenKind.Semicolon,
                    _ => throw new InvalidOperationException($"Unknown character {currentChar}")
                };

                Advance();
                return new Token(tokenKind, currentChar.ToString());
            }

            return new Token(TokenKind.EndOfFile, "");
        }

        private char Peek() => position + 1 < input.Length ? input[position + 1] : '\0';
    }
}