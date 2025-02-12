using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonLexer.Lexers;
using System.Linq;

namespace PythonLexer.Tests.LexerTests
{
    [TestClass]
    public class AssignmentLexerTests
    {
        [TestMethod]
        public void TestSimpleAssignment()
        {
            string source = "x = 42";
            ILexer lexer = new Lexers.PythonLexer(source);
            var nodes = lexer.Tokenize(source).ToList();

            Assert.AreEqual(1, nodes.Count);
        }
        
        // Additional tests...
    }
}