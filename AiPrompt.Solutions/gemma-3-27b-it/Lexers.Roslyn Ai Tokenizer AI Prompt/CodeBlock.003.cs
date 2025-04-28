// AstLexerTests/AstLexerTestClass.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstGenerator;
using AstPrettyPrinter;
using AstReflowGenerator;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstLexerTests
{
    [TestClass]
    public class AstLexerTestClass
    {
        [TestMethod]
        public void TestAstGenerationAndPrintingTuple()
        {
            // Arrange
            string sourceCode = "using System; public class MyClass { public int MyProperty { get; set; } }";
            AstGeneratorClass astGenerator = new AstGeneratorClass(sourceCode);

            // Act
            CompilationUnitSyntax compilationUnitSyntax = astGenerator.GenerateAstTuple();
            AstPrettyPrinterClass astPrettyPrinter = new AstPrettyPrinterClass(compilationUnitSyntax);
            string prettyPrintedAst = astPrettyPrinter.PrettyPrintAstTuple();

            // Assert
            Assert.IsNotNull(prettyPrintedAst);
            System.Diagnostics.Debug.WriteLine(prettyPrintedAst); // Output to Debug window for inspection
        }

        [TestMethod]
        public void TestAstReflowGenerationTuple()
        {
            // Arrange
            string sourceCode = "using System; public class MyClass { public int MyProperty { get; set; } }";
            AstGeneratorClass astGenerator = new AstGeneratorClass(sourceCode);
            CompilationUnitSyntax compilationUnitSyntax = astGenerator.GenerateAstTuple();
            AstReflowGeneratorClass astReflowGenerator = new AstReflowGeneratorClass(compilationUnitSyntax);

            // Act
            string generatedCode = astReflowGenerator.GenerateCodeTuple();

            // Assert
            Assert.AreEqual(sourceCode, generatedCode); // Verify reflowing produces the original code
        }

        // Add 23 more unit tests here to cover various scenarios and edge cases.
        // Examples:  Empty source code, invalid syntax, different types of statements, etc.
    }
}