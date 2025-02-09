[TestClass]
public class LexerTests {
    [TestMethod]
    public void TestIdentifierToken() {
        // Arrange
        var lexer = new Lexer(new StringReader("def foo(bar):"));
        
        // Act
        foreach (var token in lexer.Lex()) {
            // Assert
            Assert.AreEqual(TokenType.Identifier, token.Type);
            Assert.AreEqual("foo", token.Value); // Adjust based on test expectation
            // Repeat similar assertions for other tokens
        }
    }

    // Add additional tests for various token types and edge cases...
}