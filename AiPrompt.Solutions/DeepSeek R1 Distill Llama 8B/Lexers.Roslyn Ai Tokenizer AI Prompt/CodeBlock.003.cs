using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynASTGenerator;

namespace RoslynASTTests
{
    [TestClass]
    public class AbstractSyntaxTreeTests
    {
        private readonly AbstractSyntaxTreePrinter astPrinter = new();
        private readonly AbstractSyntaxTreeReflow astReflow = new();

        [TestMethod]
        public void TestGenerateAbstractSyntaxTree_ValidCode()
        {
            var code = "Console.WriteLine(\"Hello World\");";
            var syntaxTreeTuple = astReflow.GenerateAbstractSyntaxTree(code);
            Assert.IsNotNull(syntaxTreeTuple.SyntaxTree);
            Assert.IsNotNull(syntaxTreeTuple.CompilationUnit);
        }

        [TestMethod]
        public void TestPrettyPrint_AbstractSyntaxTree()
        {
            var code = "Console.WriteLine(\"Hello World\");";
            var syntaxTreeTuple = astReflow.GenerateAbstractSyntaxTree(code);
            var prettyPrintedString = astPrinter.PrettyPrint(syntaxTreeTuple.SyntaxTree);
            Assert.IsFalse(string.IsNullOrEmpty(prettyPrintedString));
        }

        [TestMethod]
        public void TestExecuteGeneratedCode_ValidCode()
        {
            var code = "Console.WriteLine(\"Hello World\");";
            var syntaxTreeTuple = astReflow.GenerateAbstractSyntaxTree(code);

            using (var consoleOutput = new System.IO.StringWriter())
            {
                Console.SetOut(consoleOutput);
                astReflow.ExecuteGeneratedCode(syntaxTreeTuple.CompilationUnit);

                string output = consoleOutput.ToString().Trim();
                Assert.AreEqual("Hello World", output);
            }
        }

        // Add additional tests as required to cover 25 unit tests.
    }
}