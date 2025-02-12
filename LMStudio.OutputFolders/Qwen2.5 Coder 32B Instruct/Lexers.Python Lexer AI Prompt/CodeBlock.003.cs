using System;
using System.Collections.Generic;

namespace PythonLexer.Tokenizer
{
    using Tokens;

    public class PythonTokenizer
    {
        private readonly string sourceCode;
        private int currentPos;

        public PythonTokenizer(string source)
        {
            this.sourceCode = source ?? throw new ArgumentNullException(nameof(source));
            this.currentPos = 0;
        }

        public IEnumerable<Token> GetTokens()
        {
            while (currentPos < sourceCode.Length)
            {
                char c = sourceCode[currentPos];

                if (char.IsWhiteSpace(c))
                {
                    Advance();
                    continue;
                }
                else if (c == '=')
                {
                    yield return new Token(TokenKind.EqualsSign, "=");
                    Advance();
                }
                else if (char.IsLetterOrDigit(c) || c == '_')
                {
                    int startPos = currentPos;
                    while (currentPos < sourceCode.Length && (char.IsLetterOrDigit(sourceCode[currentPos]) || sourceCode[currentPos] == '_'))
                    {
                        Advance();
                    }

                    string identifier = sourceCode.Substring(startPos, currentPos - startPos);
                    if (identifier.Equals("return", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return new Token(TokenKind.KeywordReturn, identifier);
                    }
                    else
                    {
                        yield return new Token(TokenKind.Identifier, identifier);
                    }
                }
                else if (char.IsDigit(c))
                {
                    int startPos = currentPos;
                    while (currentPos < sourceCode.Length && char.IsDigit(sourceCode[currentPos]))
                    {
                        Advance();
                    }

                    string numberLiteral = sourceCode.Substring(startPos, currentPos - startPos);
                    yield return new Token(TokenKind.NumberLiteral, numberLiteral);
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected character: {c}");
                }
            }

            yield return Token.EOF;
        }

        private void Advance()
        {
            if (currentPos < sourceCode.Length)
            {
                currentPos++;
            }
        }
    }
}