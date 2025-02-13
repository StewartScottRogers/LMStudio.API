// File: LexerTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PascaleLexer.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestSimpleProgram()
        {
            var input = @"program Example;
                begin
                    var a := 5;
                    if a > 0 then write('Positive');
                end.";
            var lexer = new Lexer(input);
            var tokens = lexer.Tokenize();

            // Add assertions for expected tokens...
        }

        [TestMethod]
        public void TestIdentifier()
        {
            var input = "aBc123";
            var lexer = new Lexer(input);
            var tokens = lexer.Tokenize();

            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Identifier, tokens[0].Type);
            Assert.AreEqual("aBc123", tokens[0].Value);
        }

        // Add more unit tests...
    }
}