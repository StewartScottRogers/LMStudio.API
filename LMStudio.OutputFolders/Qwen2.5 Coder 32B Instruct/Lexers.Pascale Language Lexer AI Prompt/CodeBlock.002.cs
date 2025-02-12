using System;
using System.Collections.Generic;

namespace PascaleLexer.Lexer
{
    public readonly struct PascaleLexer
    {
        private readonly string sourceCode;
        private int position;
        private int currentChar;

        public PascaleLexer(string source)
        {
            sourceCode = source;
            position = 0;
            currentChar = source[position];
        }

        private void Advance()
        {
            position++;
            if (position > sourceCode.Length - 1) currentChar = '\0'; // end-of-file
            else currentChar = sourceCode[position];
        }

        private void SkipWhitespace()
        {
            while (currentChar is >= ' ' and <= '\r') Advance();
        }

        private Token HandleIdentifierOrKeyword()
        {
            string result = "";
            while (char.IsLetterOrDigit(currentChar)) 
            { 
                result += currentChar;
                Advance(); 
            }
            
            var tokenType = Enum.TryParse(result, true, out TokenTypes type) ? type : TokenTypes.Identifier;
            return new Token(tokenType, result, position);
        }

        private Token HandleNumber()
        {
            string result = "";
            while (char.IsDigit(currentChar)) 
            { 
                result += currentChar; 
                Advance(); 
            }
            
            if (currentChar == '.')
            {
                result += '.';
                Advance();
                while (char.IsDigit(currentChar))
                {
                    result += currentChar;
                    Advance();
                }
                
                return new Token(TokenTypes.UnsignedReal, result, position);
            }

            return new Token(TokenTypes.UnsignedInteger, result, position);
        }

        private Token HandleStringLiteral()
        {
            string result = "";
            while (currentChar is > ' ' and < '\r' and not '\'')
            {
                result += currentChar;
                Advance();
            }
            
            Advance(); // Skip the closing quote
            return new Token(TokenTypes.StringLiteral, result, position);
        }

        public IEnumerable<Token> Lex()
        {
            while (currentChar != '\0')
            {
                if (char.IsWhiteSpace(currentChar)) SkipWhitespace();

                else if (char.IsLetter(currentChar)) yield return HandleIdentifierOrKeyword();
                
                else if (char.IsDigit(currentChar)) yield return HandleNumber();
                
                else if (currentChar == '\'') 
                { 
                    Advance(); // Skip the opening quote
                    yield return HandleStringLiteral();
                }
                
                else
                {
                    var symbol = currentChar.ToString();
                    Advance();
                    yield return new Token(TokenTypes.Symbol, symbol, position);
                }
            }

            yield return new Token(TokenTypes.Eof, string.Empty, position);
        }
    }
}