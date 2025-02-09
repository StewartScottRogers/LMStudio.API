using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LexerLibrary.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Lexer _lexer = new Lexer();

        [TestMethod]
        public void TestTokenizeSimpleStatement()
        {
            var input = "x = 42";
            var tokens = _lexer.Tokenize(input);

            // Assert statements to verify the correctness of tokenization.
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual("IDENTIFIER", tokens[0].Type);
            Assert.AreEqual("ASSIGN", tokens[1].Type);
            Assert.AreEqual("NUMBER", tokens[2].Type);
        }

        [TestMethod]
        public void TestAstNodeCreation()
        {
            var statement = new StatementNode();
            // Add children or perform other operations.
            Assert.IsNotNull(statement);
        }
    }
}