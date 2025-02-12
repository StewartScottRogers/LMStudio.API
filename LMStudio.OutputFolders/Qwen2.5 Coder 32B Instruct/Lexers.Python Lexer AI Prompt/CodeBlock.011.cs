using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonLexer.Lexers;
using System.Linq;

namespace PythonLexer.Tests.LexerTests
{
    [TestClass]
    public class ReturnStatementLexerTests
    {
        [TestMethod]
        public void TestReturnWithLiteral()
        {
            string source = "return 42";
            ILexer lexer = new Lexers.PythonLexer(source);
            var nodes = lexer.Tokenize(source).ToList();

            Assert.AreEqual(1, nodes.Count);
            Assert.IsInstanceOfType(nodes[0], typeof(Nodes.Statements.ReturnStatementNode));
        }

        [TestMethod]
        public void TestReturnWithoutExpression()
        {
            string source = "return";
            ILexer lexer = new Lexers.PythonLexer(source);
            var nodes = lexer.Tokenize(source).ToList();

            Assert.AreEqual(1, nodes.Count);
            Assert.IsInstanceOfType(nodes[0], typeof(Nodes.Statements.ReturnStatementNode));
        }

        // Additional tests...
    }
}