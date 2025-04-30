using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class WhileStmtTests
    {
        [TestMethod]
        public void TestWhileStmt()
        {
            var lexer = new Lexer("while x < 10 do x := x + 1 end");
            var whileToken = lexer.GetNextToken(); // while
            var idToken = lexer.GetNextToken(); // id
            var lessThanToken = lexer.GetNextToken(); // <
            var numberToken = lexer.GetNextToken(); // number
            var doToken = lexer.GetNextToken(); // do
            var assignIdToken = lexer.GetNextToken(); // id
            var colonEqualsToken = lexer.GetNextToken(); // :=
            var exprIdToken = lexer.GetNextToken(); // id
            var plusToken = lexer.GetNextToken(); // +
            var oneNumberToken = lexer.GetNextToken(); // number
            var endToken = lexer.GetNextToken(); // end

            Assert.AreEqual(TokenKind.While, whileToken.Kind);
            Assert.AreEqual(TokenKind.Id, idToken.Kind);
            Assert.AreEqual("<", lessThanToken.Value);
            Assert.AreEqual(TokenKind.Number, numberToken.Kind);
            Assert.AreEqual(TokenKind.Do, doToken.Kind);

            var astNode = new WhileStmt(
                new Term(), // Placeholder for actual expression logic
                new List<ASTNode>
                {
                    new AssignStmt(assignIdToken.Value, 
                        new Expr()) // Placeholder for actual expression logic
                }
            );
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.IsTrue(result.Contains("while"));
            Assert.IsTrue(result.Contains("do"));
            Assert.IsTrue(result.Contains("end"));
        }
    }
}