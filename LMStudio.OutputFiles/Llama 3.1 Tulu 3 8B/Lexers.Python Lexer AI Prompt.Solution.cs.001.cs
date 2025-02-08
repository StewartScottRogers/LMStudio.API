[TestClass]
      public class LexerTests
      {
          private const string TestInput = "def foo():\n pass";

          [TestMethod]
          public void Tokenize_Test()
          {
              var lexer = new Lexer(TestInput);
              var tokens = lexer.Tokenize().ToList();

              // Assertions here to check if the expected tokens are produced.
              Assert.AreEqual(TokenType.DefKeyword, tokens[0].Type);
              Assert.AreEqual("foo", tokens[1].Value);
              Assert.AreEqual(TokenType.Colon, tokens[2].Type);

              // Continue asserting for all tokens...
          }

          // Add 24 more tests covering a variety of grammar rules.
      }