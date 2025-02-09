// Lexer.cs
using System;
using System.IO;
using System.Text;

namespace TinyLanguageLexer
{
    public readonly struct Lexer
    {
        private readonly string sourceCode;
        private int currentPos;

        public Lexer(string sourceCode)
        {
            this.sourceCode = sourceCode ?? throw new ArgumentNullException(nameof(sourceCode));
            this.currentPos = 0;
        }

        public Token NextToken()
        {
            while (currentPos < sourceCode.Length && char.IsWhiteSpace(sourceCode[currentPos]))
                currentPos++;

            if (currentPos >= sourceCode.Length)
                return new Token(TokenKind.Unknown, string.Empty);

            var ch = sourceCode[currentPos];
            currentPos++;

            switch (ch)
            {
                case '+': return new Token(TokenKind.Plus, "+");
                case '-': return new Token(TokenKind.Minus, "-");
                case '*': return new Token(TokenKind.Star, "*");
                case '/': return new Token(TokenKind.Slash, "/");
                case '=': return Match('=', TokenKind.ColonEquals, ":=");
                case ';': return new Token(TokenKind.Semicolon, ";");
                case '(': return new Token(TokenKind.LeftParenthesis, "(");
                case ')': return new Token(TokenKind.RightParenthesis, ")");
            }

            if (char.IsDigit(ch))
                return ProcessNumber(ch);

            if (char.IsLetter(ch) || ch == '_')
                return ProcessIdentifierOrKeyword(ch);

            throw new InvalidOperationException($"Unknown character: {ch}");
        }

        private Token Match(char expectedChar, TokenKind kind, string value)
        {
            if (currentPos < sourceCode.Length && sourceCode[currentPos] == expectedChar)
            {
                currentPos++;
                return new Token(kind, value);
            }
            throw new InvalidOperationException($"Expected character: {expectedChar}");
        }

        private Token ProcessNumber(char startDigit)
        {
            var sb = new StringBuilder();
            sb.Append(startDigit);

            while (currentPos < sourceCode.Length && char.IsDigit(sourceCode[currentPos]))
                sb.Append(sourceCode[currentPos++]);

            return new Token(TokenKind.Number, sb.ToString());
        }

        private Token ProcessIdentifierOrKeyword(char startLetter)
        {
            var sb = new StringBuilder();
            sb.Append(startLetter);

            while (currentPos < sourceCode.Length && (char.IsLetterOrDigit(sourceCode[currentPos]) || sourceCode[currentPos] == '_'))
                sb.Append(sourceCode[currentPos++]);

            var identifier = sb.ToString();

            return identifier switch
            {
                "if" => new Token(TokenKind.IfKeyword, "if"),
                "then" => new Token(TokenKind.ThenKeyword, "then"),
                "while" => new Token(TokenKind.WhileKeyword, "while"),
                "do" => new Token(TokenKind.DoKeyword, "do"),
                "end" => new Token(TokenKind.EndKeyword, "end"),
                "print" => new Token(TokenKind.PrintKeyword, "print"),
                _ => new Token(TokenKind.Identifier, identifier)
            };
        }
    }
}