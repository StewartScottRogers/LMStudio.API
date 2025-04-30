using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class PrintStmtTests
    {
        [TestMethod]
        public void TestPrintStmt()
        {
            var lexer = new Lexer("print x");
            var printToken = lexer.GetNextToken(); // print
            var idToken = lexer.GetNextToken(); // id

            Assert.AreEqual(TokenKind.Print, printToken.Kind);
            Assert.AreEqual(TokenKind.Id, idToken.Kind);

            var astNode = new PrintStmt(new Id(idToken.Value));
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.AreEqual("print x\n", result);
        }
    }
}