using LexerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerTests
{
    [TestClass]
    public class IdNumberTests
    {
        [TestMethod]
        public void TestId()
        {
            var lexer = new Lexer("x");
            var idToken = lexer.GetNextToken(); // id

            Assert.AreEqual(TokenKind.Id, idToken.Kind);

            var astNode = new Id(idToken.Value);
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.AreEqual("x", result);
        }

        [TestMethod]
        public void TestNumber()
        {
            var lexer = new Lexer("123");
            var numberToken = lexer.GetNextToken(); // number

            Assert.AreEqual(TokenKind.Number, numberToken.Kind);

            var astNode = new Number(int.Parse(numberToken.Value));
            var prettyPrinter = new PrettyPrinter();
            string result = prettyPrinter.Print(astNode);

            Assert.AreEqual("123", result);
        }
    }
}