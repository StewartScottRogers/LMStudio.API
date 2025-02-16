using System;
using System.Collections.Generic;

namespace GrammarParser
{
    public class Lexer
    {
        private readonly string SourceCode;
        private int CurrentPosition = 0;
        private char CurrentChar => CurrentPosition < SourceCode.Length ? SourceCode[CurrentPosition] : '\0';

        public List<Token> Tokens { get; } = new();

        public Lexer(string source)
        {
            SourceCode = source ?? throw new ArgumentNullException(nameof(source));
        }

        public void Lex()
        {
            while (CurrentChar != '\0')
            {
                if (char.IsWhiteSpace(CurrentChar))
                    SkipWhitespace();
                else if (IsLetter(CurrentChar))
                    Tokens.Add(LexIdentifier());
                else if (IsDigit(CurrentChar))
                    Tokens.Add(new Token(TokenType.Number, CurrentChar.ToString()));
                else
                {
                    switch (CurrentChar)
                    {
                        case ':':
                            if (PeekNext() == '=')
                            {
                                Tokens.Add(new Token(TokenType.Assign, ":="));
                                Advance();
                            }
                            break;
                        case '+':
                            Tokens.Add(new Token(TokenType.Plus, "+"));
                            break;
                        case '-':
                            Tokens.Add(new Token(TokenType.Minus, "-"));
                            break;
                        case '*':
                            Tokens.Add(new Token(TokenType.Multiply, "*"));
                            break;
                        case '/':
                            Tokens.Add(new Token(TokenType.Divide, "/"));
                            break;
                        case '(':
                            Tokens.Add(new Token(TokenType.LeftParen, "("));
                            break;
                        case ')':
                            Tokens.Add(new Token(TokenType.RightParen, ")"));
                            break;
                        case ';':
                            Tokens.Add(new Token(TokenType.Semicolon, ";"));
                            break;
                        default:
                            throw new InvalidOperationException($"Unexpected character: {CurrentChar}");
                    }

                    Advance();
                }
            }

            Tokens.Add(new Token(TokenType.EndOfFile, ""));
        }

        private void SkipWhitespace()
        {
            while (char.IsWhiteSpace(CurrentChar))
                Advance();
        }

        private char PeekNext() => CurrentPosition + 1 < SourceCode.Length ? SourceCode[CurrentPosition + 1] : '\0';

        private void Advance() => CurrentPosition++;

        private bool IsLetter(char c) => char.IsLetter(c);

        private bool IsDigit(char c) => char.IsDigit(c);

        private Token LexIdentifier()
        {
            int start = CurrentPosition;
            while (IsLetter(CurrentChar) || IsDigit(CurrentChar))
                Advance();

            string identifierText = SourceCode.Substring(start, CurrentPosition - start);
            if (identifierText == "if")
                return new Token(TokenType.If, identifierText);
            else if (identifierText == "then")
                return new Token(TokenType.Then, identifierText);
            else if (identifierText == "while")
                return new Token(TokenType.While, identifierText);
            else if (identifierText == "do")
                return new Token(TokenType.Do, identifierText);
            else if (identifierText == "end")
                return new Token(TokenType.End, identifierText);
            else if (identifierText == "print")
                return new Token(TokenType.Print, identifierText);

            return new Token(TokenType.Identifier, identifierText);
        }
    }

    public record Token
    {
        public TokenType Type { get; init; }
        public string Text { get; init; }

        public Token(TokenType type, string text)
        {
            Type = type;
            Text = text;
        }
    }

    public enum TokenType
    {
        EndOfFile,
        Identifier,
        Number,
        Assign,
        Plus,
        Minus,
        Multiply,
        Divide,
        LeftParen,
        RightParen,
        Semicolon,
        If,
        Then,
        While,
        Do,
        End,
        Print
    }
}