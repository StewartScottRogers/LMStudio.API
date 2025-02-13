using System;
using System.Collections.Generic;
using System.IO;

namespace PythonLexer
{
    public class Lexer
    {
        private readonly string input;
        private int position = 0;
        private readonly Dictionary<string, TokenType> keywords = new Dictionary<string, TokenType>
        {
            { "False", TokenType. False},
            { "None", TokenType.None },
            { "True", TokenType.True},
            {"async" ,TokenType.Async },
            {"await",TokenType.Await }
            // Add more token types as needed
        }
    }
}