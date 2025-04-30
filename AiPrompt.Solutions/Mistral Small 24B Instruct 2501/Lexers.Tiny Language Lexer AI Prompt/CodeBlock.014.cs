using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class AssignStmtTests
    {
        [TestMethod]
        public void TestAssignStmt()
        {
            var lexer = new Lexer("x := 10");
            var assignToken = lexer.GetNextToken(); // id
            var colonEqualsToken = lexer.GetNextToken(); // :=
            var numberToken = lexer.GetNextToken(); // number

            Assert.AreEqual(TokenKind.Id, assignToken.Kind);
            Assert.AreEqual(TokenKind.Assign, colonEqualsToken.Kind);
            Assert.AreEqual(TokenKind.Number, numberToken.Kind);

            var astNode = new AssignStmt(assignToken.Value, new Number(int.Parse(numberToken.Value)));
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.AreEqual("x := 10", result);
        }
    }
}