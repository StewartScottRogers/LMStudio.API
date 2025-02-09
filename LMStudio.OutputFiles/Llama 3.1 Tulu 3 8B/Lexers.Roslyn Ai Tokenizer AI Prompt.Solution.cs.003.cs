[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestLexingSimpleProgram()
    {
        // Arrange
        var input = @"class HelloWorld {
                                static void Main(string[] args) {
                                    System.Console.WriteLine(""Hello World"");
                                }}";
        
        // Act
        var ast = LexInput(input);  // Implement this method to parse the input into an AST.
        var prettyPrintedAst = AstPrettyPrinter.Print(ast);
        var reflowedCode = AstReflowGenerator.Reflow(ast);
        
        // Assert
        // Ensure the printed AST looks correct
        Assert.IsNotNull(prettyPrintedAst);
        // Compile and execute refloowed code, verify expected output.
        var compilationResult = AstReflowGenerator.CompileAndCheck(reflowedCode);
        var diagnostics = compilationResult.Diagnostics;
        Assert.IsTrue(diagnostics.Errors.IsEmpty);  // No errors should be present
        
        // Placeholder for actual execution verification if needed
    }

    [Repeat]
    [DataRow("int x = 5;", ExpectedTokens.Count == 4)]
    [DataTestMethod]
    public void TestLexingSingleStatements(string input, int expectedTokensCount)
    {
        // Arrange & Act (similar to the previous test but for a single statement)

        // Assert
        var ast = LexInput(input);
        // Ensure tokens are correctly counted and processed here.
    }

    // Repeat this structure for 25 unit tests covering different scenarios such as comments, keywords, identifiers, literals etc.

}