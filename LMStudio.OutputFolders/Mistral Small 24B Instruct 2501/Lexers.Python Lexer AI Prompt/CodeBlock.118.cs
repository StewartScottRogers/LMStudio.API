using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer : ILexer
    {
        private readonly string input;
        private int position = 0;
        private readonly Dictionary<string, TokenType> keywordMap;

        public Lexer(string input)
        {
            this.input = input;
            InitializeKeywordMap();
        }

        private void InitializeKeywordMap()
        {
            keywordMap = new Dictionary<string, TokenType>
            {
                { "import", TokenType.Import },
                { "from", TokenType.From },
                { "as", TokenType.As },
                { "def", TokenType.Def },
                { "class", TokenType.Class },
                { "if", TokenType.If },
                { "elif", TokenType.Elif },
                { "else", TokenType.Else },
                { "for", TokenType.For },
                { "while", TokenType.While },
                { "with", TokenType.With },
                { "try", TokenType.Try},
                { "except", TokenType.Except },
                { "finally", TokenType.Finally },
                { "match", TokenType.Match },
                { "case", TokenType.Case },
                { "import", TokenType.Import },
                { "from", TokenType.From },
                { "as", TokenType.As },
                { "def", TokenType.Def },
                { "class", TokenType.Class },
                { "if", TokenType.If },
                { "elif", TokenType.Elif },
                { "else", TokenType.Else },
                { "for", TokenType.For },
                { "while", TokenType.While },
                { "with", TokenType.With },
                { "try", TokenType.Try },
                { "except", TokenType.Except },
                { "finally", TokenType.Finally },
                { "match", TypeMatch },
                { "case", TypeCase },
                { "import", TypeImport },
                { "from", TypeFrom },
                { "as", TypeAs },
                { "del", TypeDel },
                { "global", TypeGlobal },
                { "nonlocal", TypeNonLocal },
                { "assert", TypeAssert },
                { "lambda", TypeLambda },
                { "if", TypeIf },
                { "elif", TypeElif },
                { "else", TypeElse },
                { "try", TypeTry },
                { "finally", TypeFinally },
                { "except", TypeExcept },
                { "match", TypeMatch },
                { "case", TypeCase },
                { "while", TypeWhile },
                { "for", TypeFor },
                { "with", TypeWith },
                { "if", TypeIf },
                { "elif", TypeElif },
                { "else", TypeElse },
                { "try", TypeTry },
                { "except", TypeExcept },
                { "finally", TypeFinally },
                { "raise", TypeRaise },
                { "return", TypeReturn },
                { "pass", TypePass },
                { "del", TypeDel },
                { "yield", TypeYield }
                { "assert", TypeAssert }

Given the requirements and the grammar provided, let's break down the solution into manageable steps. We'll create a .NET 9.0 Class Library project in Visual Studio 2022 that includes:

1. A Lexer for the Abstract Syntax Tree (AST).
2. An AST Pretty Printer.
3. All nodes in the AST.
4. Unit tests for lexing the AST.

### Solution Structure

The solution will be organized as follows: