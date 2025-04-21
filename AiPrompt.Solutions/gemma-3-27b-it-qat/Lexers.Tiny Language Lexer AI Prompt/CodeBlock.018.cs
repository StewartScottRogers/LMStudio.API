using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexerLibrary;

namespace LexerTests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestIdentifier()
        {
            var lexer = new Lexer("abc");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Identifier, token.Type);
            Assert.AreEqual("abc", token.Value);
        }

        [TestMethod]
        public void TestNumber()
        {
            var lexer = new Lexer("123");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Number, token.Type);
            Assert.AreEqual("123", token.Value);
        }

        [TestMethod]
        public void TestPlus()
        {
            var lexer = new Lexer("+");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Plus, token.Type);
            Assert.AreEqual("+", token.Value);
        }

        [TestMethod]
        public void TestMinus()
        {
            var lexer = new Lexer("-");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Minus, token.Type);
            Assert.AreEqual("-", token.Value);
        }

        [TestMethod]
        public void TestMultiply()
        {
            var lexer = new Lexer("*");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Multiply, token.Type);
            Assert.AreEqual("*", token.Value);
        }

        [TestMethod]
        public void TestDivide()
        {
            var lexer = new Lexer("/");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Divide, token.Type);
            Assert.AreEqual("/", token.Value);
        }

        [TestMethod]
        public void TestAssign()
        {
            var lexer = new Lexer(":=");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Assign, token.Type);
            Assert.AreEqual(":=", token.Value);
        }

        [TestMethod]
        public void TestIfKeyword()
        {
            var lexer = new Lexer("if");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.IfKeyword, token.Type);
            Assert.AreEqual("if", token.Value);
        }

        [TestMethod]
        public void TestThenKeyword()
        {
            var lexer = new Lexer("then");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.ThenKeyword, token.Type);
            Assert.AreEqual("then", token.Value);
        }

        [TestMethod]
        public void TestEndKeyword()
        {
            var lexer = new Lexer("end");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.EndKeyword, token.Type);
            Assert.AreEqual("end", token.Value);
        }

        [TestMethod]
        public void TestWhileKeyword()
        {
            var lexer = new Lexer("while");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.WhileKeyword, token.Type);
            Assert.AreEqual("while", token.Value);
        }

        [TestMethod]
        public void TestDoKeyword()
        {
            var lexer = new Lexer("do");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.DoKeyword, token.Type);
            Assert.AreEqual("do", token.Value);
        }

        [TestMethod]
        public void TestPrintKeyword()
        {
            var lexer = new Lexer("print");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.PrintKeyword, token.Type);
            Assert.AreEqual("print", token.Value);
        }

        [TestMethod]
        public void TestLeftParen()
        {
            var lexer = new Lexer("(");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.LeftParen, token.Type);
            Assert.AreEqual("(", token.Value);
        }

        [TestMethod]
        public void TestRightParen()
        {
            var lexer = new Lexer(")");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.RightParen, token.Type);
            Assert.AreEqual(")", token.Value);
        }

        [TestMethod]
        public void TestSemicolon()
        {
            var lexer = new Lexer(";");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Semicolon, token.Type);
            Assert.AreEqual(";", token.Value);
        }

        [TestMethod]
        public void TestWhitespace()
        {
            var lexer = new Lexer("  abc");
            (Token token, string remainingInput) = lexer.GetNextToken();
            Assert.AreEqual(TokenType.Identifier, token.Type);
            Assert.AreEqual("abc", token.Value);
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            var lexer = new Lexer("a + b * c");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();
            (Token token3, _) = lexer.GetNextToken();
            (Token token4, _) = lexer.GetNextToken();
            (Token token5, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.Identifier, token1.Type);
            Assert.AreEqual(TokenType.Plus, token2.Type);
            Assert.AreEqual(TokenType.Identifier, token3.Type);
            Assert.AreEqual(TokenType.Multiply, token4.Type);
            Assert.AreEqual(TokenType.Identifier, token5.Type);
        }

        [TestMethod]
        public void TestAssignStatement()
        {
            var lexer = new Lexer("x := 10");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();
            (Token token3, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.Identifier, token1.Type);
            Assert.AreEqual(TokenType.Assign, token2.Type);
            Assert.AreEqual(TokenType.Number, token3.Type);
        }

        [TestMethod]
        public void TestIfStatement()
        {
            var lexer = new Lexer("if a then end");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();
            (Token token3, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.IfKeyword, token1.Type);
            Assert.AreEqual(TokenType.Identifier, token2.Type);
            Assert.AreEqual(TokenType.ThenKeyword, token3.Type);
        }

        [TestMethod]
        public void TestWhileStatement()
        {
            var lexer = new Lexer("while a do end");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();
            (Token token3, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.WhileKeyword, token1.Type);
            Assert.AreEqual(TokenType.Identifier, token2.Type);
            Assert.AreEqual(TokenType.DoKeyword, token3.Type);
        }

        [TestMethod]
        public void TestPrintStatement()
        {
            var lexer = new Lexer("print a");
            (Token token1, _) = lexer.GetNextToken();
            (Token token2, _) = lexer.GetNextToken();

            Assert.AreEqual(TokenType.PrintKeyword, token1.Type);
            Assert.AreEqual(TokenType.Identifier, token2.Type);
        }

    }
}