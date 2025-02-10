// File: Lexer.cs
using System;
using System.Collections.Generic;

namespace PythonLexer
{
    public class Lexer
    {
        private readonly string Input;
        private int Position = 0;
        private readonly Dictionary<string, TokenType> Keywords;

        public Lexer(string input)
        {
            this.Input = input;
            this.Keywords = new Dictionary<string, TokenType>
            {
                { "def", TokenType.Def },
                { "return", TokenType.Return },
                { "class", TokenType.Class },
                { "if", TokenType.If },
                { "elif", TokenType.Elif },
                { "else", TokenType.Else },
                { "while", TokenType.While },
                { "for", TokenType.For },
                { "with", TokenType.With },
                { "try", TypeToken.Try},
                { "except", TypeToken.Except },
                {"finally", TypeToken.Finally},
                {"match", TypeToken.Match },
                {"case", TypeToken.Case}