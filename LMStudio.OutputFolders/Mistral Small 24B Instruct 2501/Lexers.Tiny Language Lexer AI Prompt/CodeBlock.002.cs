// File: Lexer.cs
using System.Collections.Generic;

namespace LexerLibrary.Lexer
{
    public class Lexer
    {
        private readonly string input;
        private int position;

        public Lexer(string input)
        {
            this.input = input;
            position = 0;
        }

        public var TokenListTuple GetTokens()
        {
            var tokens = new List<Token>();
            while (position < input.Length)
            {
                char currentChar = input[position];
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                }
                else if (char.IsLetter(currentChar))
                {
                    string id = ReadIdentifier();
                    TokenType type;
                    switch (id)
                    {
                        case "if":
                            type = TokenType.If;
                            break;
                        case "then":
                            type = TokenType.Then;
                            break;
                        case "end":
                            type = TokenType.End;
                            break;
                        case "while":
                            type = TokenType.While;
                            break;
                        case "do":
                            type = TokenType.Do;
                            break;
                        case "print":
                            type = TokenType.Print;
                            break;
                        default:
                            type = TokenType.Id;
                            break;
                    }
                    tokens.Add(new Token(type, id));
                }
                else if (char.IsDigit(currentChar))
                {
                    string number = ReadNumber();
                    tokens.Add(new Token(TokenType.Number, number));
                }
                else
                {
                    switch (currentChar)
                    {
                        case '+':
                            tokens.Add(new Token(TokenType.Plus, "+"));
                            position++;
                            break;
                        case '-':
                            tokens.Add(new Token(TokenType.Minus, "-"));
                            position++;
                            break;
                        case '*':
                            tokens.Add(new Token(TokenType.Multiply, "*"));
                            position++;
                            break;
                        case '/':
                            tokens.Add(new Token(TokenType.Divide, "/"));
                            position++;
                            break;
                        case ':':
                            if (position + 1 < input.Length && input[position + 1] == '=')
                            {
                                tokens.Add(new Token(TokenType.Assign, ":="));
                                position += 2;
                            }
                            else
                            {
                                throw new System.Exception("Invalid character sequence.");
                            }
                            break;
                        case '(':
                            tokens.Add(new Token(TokenType.Lparen, "("));
                            position++;
                            break;
                        case ')':
                            tokens.Add(new Token(TokenType.Rparen, ")"));
                            position++;
                            break;
                        case ';':
                            tokens.Add(new Token(TokenType.Semicolon, ";"));
                            position++;
                            break;
                        default:
                            throw new System.Exception("Invalid character: " + currentChar);
                    }
                }
            }
            tokens.Add(new Token(TokenType.Eof, ""));
            return (tokens);
        }

        private string ReadIdentifier()
        {
            int start = position;
            while (position < input.Length && (char.IsLetterOrDigit(input[position])))
            {
                position++;
            }
            return input.Substring(start, position - start);
        }

        private string ReadNumber()
        {
            int start = position;
            while (position < input.Length && char.IsDigit(input[position]))
            {
                position++;
            }
            return input.Substring(start, position - start);
        }
    }
}