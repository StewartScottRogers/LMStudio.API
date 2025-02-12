using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis;

[TestClass]
public class CodeGeneratorTests
{
    [TestMethod]
    public void TestGenerateCode()
    {
        var lexer = new LexerService();
        string code = "class Sample { }";
        SyntaxTree tree = lexer.GenerateSyntaxTree(code);
        var generator = new CodeGenerator();
        string generatedCode = generator.GenerateCode(tree);
        Assert.IsNotNull(generatedCode);
    }
}