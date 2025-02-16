using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GrammarParser.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestSimpleAssignStmt()
        {
            var source = "a := 1";
            var lexer = new Lexer(source);
            lexer.Lex();

            var expectedTokens = new List<Lexer.Token>
            {
                new Lexer.Token(Lexer.TokenType.Identifier, "a"),
                new Lexer.Token(Lexer.TokenType.Assign, ":="),
                new Lexer.Token(Lexer.TokenType.Number, "1"),
                new Lexer.Token(Lexer.TokenType.EndOfFile, "")
            };

            CollectionAssert.AreEqual(expectedTokens, lexer.Tokens);
        }

        [TestMethod]
        public void TestIfStmt()
        {
            var source = "if a then b := 2 end";
            var lexer = new Lexer(source);
            lexer.Lex();

            var expectedTokens = new List<Lexer.Token>
            {
                new Lexer.Token(Lexer.TokenType.If, "if"),
                new Lexer.Token(Lexer.TokenType.Identifier, "a"),
                new Lexer.Token(Lexer.TokenType.Then, "then"),
                new Lexer.Token(Lexer.TokenType.Identifier, "b"),
                new Lexer.Token(Lexer.TokenType.Assign, ":="),
                new Lexer.Token(Lexer.TokenType.Number, "2"),
                new Lexer.Token(Lexer.TokenType.End, "end"),
                new Lexer.Token(Lexer.TokenType.EndOfFile, "")
            };

            CollectionAssert.AreEqual(expectedTokens, lexer.Tokens);
        }

        [TestMethod]
        public void TestWhileStmt()
        {
            var source = "while a do b := 3 end";
            var lexer = new Lexer(source);
            lexer.Lex();

            var expectedTokens = new List<Lexer.Token>
            {
                new Lexer.Token(Lexer.TokenType.While, "while"),
                new Lexer.Token(Lexer.TokenType.Identifier, "a"),
                new Lexer.Token(Lexer.TokenType.Do, "do"),
                new Lexer.Token(Lexer.TokenType.Identifier, "b"),
                new Lexer.Token(Lexer.TokenType.Assign, ":="),
                new Lexer.Token(Lexer.TokenType.Number, "3"),
                new Lexer.Token(Lexer.TokenType.End, "end"),
                new Lexer.Token(Lexer.TokenType.EndOfFile, "")
            };

            CollectionAssert.AreEqual(expectedTokens, lexer.Tokens);
        }

        [TestMethod]
        public void TestPrintStmt()
        {
            var source = "print a";
            var lexer = new Lexer(source);
            lexer.Lex();

            var expectedTokens = new List<Lexer.Token>
            {
                new Lexer.Token(Lexer.TokenType.Print, "print"),
                new Lexer.Token(Lexer.TokenType.Identifier, "a"),
                new Lexer.Token(Lexer.TokenType.EndOfFile, "")
            };

            CollectionAssert.AreEqual(expectedTokens, lexer.Tokens);
        }

        [TestMethod]
        public void TestExprWithBinaryOps()
        {
            var source = "(a + b) * (c - 3)";
            var lexer = new Lexer(source);
            lexer.Lex();

            var expectedTokens = new List<Lexer.Token>
            {
                new Lexer.Token(Lexer.TokenType.LeftParen, "("),
                new Lexer.Token(Lexer.TokenType.Identifier, "a"),
                new Lexer.Token(Lexer.TokenType.Plus, "+"),
                new Lexer.Token(Lexer.TokenType.Identifier, "b"),
                new Lexer.Token(Lexer.TokenType.RightParen, ")"),
                new Lexer.Token(Lexer.TokenType.Multiply, "*"),
                new Lexer.Token(Lexer.TokenType.LeftParen, "("),
                new Lexer.Token(Lexer.TokenType.Identifier, "c"),
                new Lexer.Token(Lexer.TokenType.Minus, "-"),
                new Lexer.Token(Lexer.TokenType.Number, "3"),
                new Lexer.Token(Lexer.TokenType.RightParen, ")"),
                new Lexer.Token(Lexer.TokenType.EndOfFile, "")
            };

            CollectionAssert.AreEqual(expectedTokens, lexer.Tokens);
        }

        [TestMethod]
        public void TestStmtList()
        {
            var source = "a := 1; b := 2";
            var lexer = new Lexer(source);
            lexer.Lex();

            var expectedTokens = new List<Lexer.Token>
            {
                new Lexer.Token(Lexer.TokenType.Identifier, "a"),
                new Lexer.Token(Lexer.TokenType.Assign, ":="),
                new Lexer.Token(Lexer.TokenType.Number, "1"),
                new Lexer.Token(Lexer.TokenType.Semicolon, ";"),
                new Lexer.Token(Lexer.TokenType.Identifier, "b"),
                new Lexer.Token(Lexer.TokenType.Assign, ":="),
                new Lexer.Token(Lexer.TokenType.Number, "2"),
                new Lexer.Token(Lexer.TokenType.EndOfFile, "")
            };

            CollectionAssert.AreEqual(expectedTokens, lexer.Tokens);
        }
    }
}