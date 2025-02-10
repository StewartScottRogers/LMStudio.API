using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class TokenType
    {
        public readonly string Name;

        private TokenType(string name)
        {
            Name = name;
        }

        // Define all token types here
        public static readonly TokenType Identifier = new("Identifier");
        public static readonly TokenType Number = new("Number");
        public static readonly TokenType StringLiteral = new("StringLiteral");
        public static readonly TokenType Keyword = new("Keyword");

        // Add other token types as needed based on the grammar

        private TokenType( string name) {
            Name = name;
        }
        public readonly string Name;

    }