using System;
using System.Collections.Generic;
using System.Text;

namespace LexerLibrary
{
    /// <summary>
    /// Lexical analyzer that converts source code into tokens.
    /// </summary>
    public class Lexer
    {
        private readonly string SourceCode;
        private int CurrentPosition;
        private readonly int SourceLength;

        /// <summary>
        /// Initializes a new instance of the Lexer class with the given source code.
        /// </summary>
        /// <param name="sourceCode">The source code to lex.</param>
        public Lexer(string sourceCode)
        {
            SourceCode = sourceCode;
            CurrentPosition = 0;
            SourceLength = sourceCode.Length;
        }

        /// <summary>
        /// Gets the next token from the source code.
        /// </summary>
        /// <returns>A tuple containing the token type and value.</returns>
        public (TokenType TokenType, string Value) NextTokenTuple()
        {
            // Skip whitespace
            while (CurrentPosition < SourceLength && char.IsWhiteSpace(SourceCode[CurrentPosition]))
            {
                CurrentPosition++;
            }

            // Check for end of file
            if (CurrentPosition >= SourceLength)
            {
                return (TokenType.Eof, string.Empty);
            }

            char currentChar = SourceCode[CurrentPosition];

            // Handle different token types
            return currentChar switch
            {
                ':' when CurrentPosition + 1 < SourceLength && SourceCode[CurrentPosition + 1] == '=' =>
                    AdvanceAndReturnToken(TokenType.Assign, 2),
                '+' => AdvanceAndReturnToken(TokenType.Plus, 1),
                '-' => AdvanceAndReturnToken(TokenType.Minus, 1),
                '*' => AdvanceAndReturnToken(TokenType.Multiply, 1),
                '/' => AdvanceAndReturnToken(TokenType.Divide, 1),
                '(' => AdvanceAndReturnToken(TokenType.LeftParen, 1),
                ')' => AdvanceAndReturnToken(TokenType.RightParen, 1),
                ';' => AdvanceAndReturnToken(TokenType.Semicolon, 1),
                _ when char.IsLetter(currentChar) => ReadIdentifierTuple(),
                _ when char.IsDigit(currentChar) => ReadNumberTuple(),
                _ => (TokenType.Unknown, currentChar.ToString())
            };
        }

        /// <summary>
        /// Reads an identifier from the source code.
        /// </summary>
        /// <returns>A tuple containing the token type and value for the identifier.</returns>
        private (TokenType TokenType, string Value) ReadIdentifierTuple()
        {
            var identifierBuilder = new StringBuilder();
            
            while (CurrentPosition < SourceLength && 
                   (char.IsLetter(SourceCode[CurrentPosition]) || char.IsDigit(SourceCode[CurrentPosition])))
            {
                identifierBuilder.Append(SourceCode[CurrentPosition]);
                CurrentPosition++;
            }
            
            string identifierValue = identifierBuilder.ToString();
            
            // Check for reserved keywords
            return identifierValue.ToLower() switch
            {
                "if" => (TokenType.If, identifierValue),
                "then" => (TokenType.Then, identifierValue),
                "end" => (TokenType.End, identifierValue),
                "while" => (TokenType.While, identifierValue),
                "do" => (TokenType.Do, identifierValue),
                "print" => (TokenType.Print, identifierValue),
                _ => (TokenType.Identifier, identifierValue)
            };
        }

        /// <summary>
        /// Reads a number from the source code.
        /// </summary>
        /// <returns>A tuple containing the token type and value for the number.</returns>
        private (TokenType TokenType, string Value) ReadNumberTuple()
        {
            var numberBuilder = new StringBuilder();
            
            while (CurrentPosition < SourceLength && char.IsDigit(SourceCode[CurrentPosition]))
            {
                numberBuilder.Append(SourceCode[CurrentPosition]);
                CurrentPosition++;
            }
            
            return (TokenType.Number, numberBuilder.ToString());
        }

        /// <summary>
        /// Advances the current position and returns a token.
        /// </summary>
        /// <param name="tokenType">The type of token to return.</param>
        /// <param name="advanceCount">Number of characters to advance.</param>
        /// <returns>A tuple containing the specified token type and value.</returns>
        private (TokenType TokenType, string Value) AdvanceAndReturnToken(TokenType tokenType, int advanceCount)
        {
            CurrentPosition += advanceCount;
            return (tokenType, tokenType.ToString());
        }
    }
}