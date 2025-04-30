using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class IfStmtTests
    {
        [TestMethod]
        public void TestIfStmt()
        {
            var lexer = new Lexer("if x > y then x := 10 end");
            var ifToken = lexer.GetNextToken(); // if
            var idToken = lexer.GetNextToken(); // id
            var greaterThanToken = lexer.GetNextToken(); // >
            var yIdToken = lexer.GetNextToken(); // id
            var thenToken = lexer.GetNextToken(); // then
            var assignToken = lexer.GetNextToken(); // id
            var colonEqualsToken = lexer.GetNextToken(); // :=
            var numberToken = lexer.GetNextToken(); // number
            var endToken = lexer.GetNextToken(); // end

            Assert.AreEqual(TokenKind.If, ifToken.Kind);
            Assert.AreEqual(TokenKind.Id, idToken.Kind);
            Assert.AreEqual(">", greaterThanToken.Value);
            Assert.AreEqual(TokenKind.Id, yIdToken.Kind);
            Assert.AreEqual(TokenKind.Then, thenToken.Kind);

            var astNode = new IfStmt(
                new Term(), // Placeholder for actual expression logic
                new List<ASTNode>
                {
                    new AssignStmt(assignToken.Value, new Number(int.Parse(numberToken.Value)))
                }
            );
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.IsTrue(result.Contains("if"));
            Assert.IsTrue(result.Contains("then"));
            Assert.IsTrue(result.Contains("end"));
        }
    }
}