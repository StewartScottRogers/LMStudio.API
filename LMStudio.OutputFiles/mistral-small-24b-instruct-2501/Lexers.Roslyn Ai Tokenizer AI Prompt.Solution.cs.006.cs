using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AstReflowGeneratorTests
{
    [TestMethod]
    public void TestGenerateCode()
    {
        var sourceCode = @"namespace Example { public class HelloWorld { public static void Main() { Console.WriteLine(""Hello, World!""); } } }";
        var lexer = new RoslynLexer(sourceCode);
        var syntaxTree = lexer.GenerateSyntaxTree();
        var root = syntaxTree.GetRoot();

        var reflowGenerator = new AstReflowGenerator(root);
        var generatedCode = reflowGenerator.GenerateCode();

        Console.WriteLine(generatedCode); // Execute the generated code
        Assert.IsNotNull(generatedCode);

        // Add more tests for bounding conditions
    }
}