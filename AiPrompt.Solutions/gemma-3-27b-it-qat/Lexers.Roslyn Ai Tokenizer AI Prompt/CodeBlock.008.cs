using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstGenerator.Core;

namespace AstGenerator.Tests;

[TestClass]
public class AstLexingTests
{
    [TestMethod]
    public void TestGenerateAstFromSimpleCode()
    {
        // Arrange
        readonly string sourceCode = "int x = 10;";
        CompilationUnit compilationUnit = new();

        // Act
        var (syntaxTreeTuple, unitTuple) = compilationUnit.GenerateAstFromCode(sourceCode);

        // Assert
        Assert.IsNotNull(syntaxTreeTuple);
    }

    [TestMethod]
    public void TestPrettyPrintAst()
    {
        // Arrange
        CompilationUnit compilationUnit = new();
        compilationUnit.AddStatement("int x = 10;", NodeType.VariableDeclaration);
        compilationUnit.AddStatement("x = 20;", NodeType.AssignmentStatement);

        // Act
        AstPrettyPrinter printer = new();
        string prettyPrintedAst = printer.Print(compilationUnit);

        // Assert
        Assert.AreEqual("VariableDeclaration: int x = 10;\n", prettyPrintedAst);
    }

    [TestMethod]
    public void TestReflowAst()
    {
        // Arrange
        CompilationUnit compilationUnit = new();
        compilationUnit.AddStatement("int x = 10;", NodeType.VariableDeclaration);
        readonly string sourceCode = "int x = 10;";

        // Act
        AstReflowGenerator reflower = new();
        reflower.Reflow(compilationUnit, sourceCode);

        // Assert - This test currently only checks that the method runs without errors.  More robust testing would involve verifying generated code.
    }
}