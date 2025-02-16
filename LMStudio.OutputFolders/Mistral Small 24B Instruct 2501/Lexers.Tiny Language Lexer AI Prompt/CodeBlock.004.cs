// File: LexerTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LexerLibrary.UnitTests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestSimpleAssignment()
        {
            var lexer = new Lexer.Lexer("x := 1;");
            var tokens = lexer.GetTokens().tokens;
            Assert.AreEqual(4, tokens.Count);
            Assert.AreEqual(TokenType.Id, tokens[0].Type);
            Assert.AreEqual("x", tokens[0].Value);
            Assert.AreEqual(TokenType.Assign, tokens[1].Type);
            Assert.AreEqual(":=", tokens[1].Value);
            Assert.AreEqual(TokenType.Number, tokens[2].Type);
            Assert.AreEqual("1", tokens[2].Value);
            Assert.AreEqual(TokenType.Semicolon, tokens[3].Type);
        }

        [TestMethod]
        public void TestIfStatement()
        {
            var lexer = new Lexer.Lexer("if x > 0 then y := x; end;");
            var tokens = lexer.GetTokens().tokens;
            Assert.AreEqual(11, tokens.Count);
            // Add more assertions for other tokens
        }

        [TestMethod]
        public void TestWhileStatement()
        {
            var lexer = new Lexer.Lexer("while x > 0 do y := x; end;");
            var tokens = lexer.GetTokens().tokens;
            Assert.AreEqual(12, tokens.Count);
            // Add more assertions for other tokens
        }

        [TestMethod]
        public void TestPrintStatement()
        {
            var lexer = new Lexer.Lexer("print x;");
            var tokens = lexer.GetTokens().tokens;
            Assert.AreEqual(3, tokens.Count);
            // Add more assertions for other tokens
        }
    }
}