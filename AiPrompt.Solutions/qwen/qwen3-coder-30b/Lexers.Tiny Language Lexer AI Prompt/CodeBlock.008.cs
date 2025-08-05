using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexerLibrary;

namespace LexerTests
{
    [TestClass]
    public class LexerTests
    {
        /// <summary>
        /// Test that the lexer correctly identifies a single identifier.
        /// </summary>
        [TestMethod]
        public void TestSingleIdentifier()
        {
            var lexer = new Lexer("x");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a single number.
        /// </summary>
        [TestMethod]
        public void TestSingleNumber()
        {
            var lexer = new Lexer("42");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("42", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple assignment.
        /// </summary>
        [TestMethod]
        public void TestAssignment()
        {
            var lexer = new Lexer("x := 5");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("5", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple if statement.
        /// </summary>
        [TestMethod]
        public void TestIfStatement()
        {
            var lexer = new Lexer("if x then end");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.If, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Then, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple while statement.
        /// </summary>
        [TestMethod]
        public void TestWhileStatement()
        {
            var lexer = new Lexer("while x do end");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.While, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Do, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple print statement.
        /// </summary>
        [TestMethod]
        public void TestPrintStatement()
        {
            var lexer = new Lexer("print x");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Print, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple addition.
        /// </summary>
        [TestMethod]
        public void TestAddition()
        {
            var lexer = new Lexer("x + y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple subtraction.
        /// </summary>
        [TestMethod]
        public void TestSubtraction()
        {
            var lexer = new Lexer("x - y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Minus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple multiplication.
        /// </summary>
        [TestMethod]
        public void TestMultiplication()
        {
            var lexer = new Lexer("x * y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a simple division.
        /// </summary>
        [TestMethod]
        public void TestDivision()
        {
            var lexer = new Lexer("x / y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Divide, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies parentheses.
        /// </summary>
        [TestMethod]
        public void TestParentheses()
        {
            var lexer = new Lexer("(x)");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.LeftParen, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.RightParen, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a semicolon.
        /// </summary>
        [TestMethod]
        public void TestSemicolon()
        {
            var lexer = new Lexer("x;");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex expression.
        /// </summary>
        [TestMethod]
        public void TestComplexExpression()
        {
            var lexer = new Lexer("x + y * z");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex assignment.
        /// </summary>
        [TestMethod]
        public void TestComplexAssignment()
        {
            var lexer = new Lexer("x := y + z");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex if statement.
        /// </summary>
        [TestMethod]
        public void TestComplexIfStatement()
        {
            var lexer = new Lexer("if x + y then z := 5; end");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.If, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Then, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("5", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex while statement.
        /// </summary>
        [TestMethod]
        public void TestComplexWhileStatement()
        {
            var lexer = new Lexer("while x * y do z := 5; end");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.While, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Do, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("5", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex print statement.
        /// </summary>
        [TestMethod]
        public void TestComplexPrintStatement()
        {
            var lexer = new Lexer("print x + y");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Print, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a multi-character identifier.
        /// </summary>
        [TestMethod]
        public void TestMultiCharacterIdentifier()
        {
            var lexer = new Lexer("variable123");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("variable123", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a multi-digit number.
        /// </summary>
        [TestMethod]
        public void TestMultiDigitNumber()
        {
            var lexer = new Lexer("12345");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("12345", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies whitespace handling.
        /// </summary>
        [TestMethod]
        public void TestWhitespaceHandling()
        {
            var lexer = new Lexer("  x   :=   5  ");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("5", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies keywords.
        /// </summary>
        [TestMethod]
        public void TestKeywords()
        {
            var lexer = new Lexer("if then end while do print");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.If, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Then, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.End, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.While, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Do, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Print, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies an empty input.
        /// </summary>
        [TestMethod]
        public void TestEmptyInput()
        {
            var lexer = new Lexer("");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a complex nested expression.
        /// </summary>
        [TestMethod]
        public void TestNestedExpression()
        {
            var lexer = new Lexer("(x + y) * z");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.LeftParen, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.RightParen, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies an expression with multiple operators.
        /// </summary>
        [TestMethod]
        public void TestMultipleOperators()
        {
            var lexer = new Lexer("x + y - z * w");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Plus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Minus, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("z", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Multiply, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("w", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly identifies a statement with multiple semicolons.
        /// </summary>
        [TestMethod]
        public void TestMultipleSemicolons()
        {
            var lexer = new Lexer("x := 1; y := 2;");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("x", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("1", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("y", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Assign, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Number, tokenTuple.TokenType);
            Assert.AreEqual("2", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Semicolon, tokenTuple.TokenType);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }

        /// <summary>
        /// Test that the lexer correctly handles mixed case identifiers.
        /// </summary>
        [TestMethod]
        public void TestMixedCaseIdentifiers()
        {
            var lexer = new Lexer("VariableName");
            var tokenTuple = lexer.NextTokenTuple();
            
            Assert.AreEqual(TokenType.Identifier, tokenTuple.TokenType);
            Assert.AreEqual("VariableName", tokenTuple.Value);
            
            tokenTuple = lexer.NextTokenTuple();
            Assert.AreEqual(TokenType.Eof, tokenTuple.TokenType);
        }
    }
}