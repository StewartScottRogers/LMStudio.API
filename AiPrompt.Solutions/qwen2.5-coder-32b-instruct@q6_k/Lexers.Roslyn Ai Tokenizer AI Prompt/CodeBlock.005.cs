using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynAstLibrary
{
    [TestClass]
    public class AstBuilderTests
    {
        private readonly ITestCase testCase;
        private readonly AbstractSyntaxTreePrinter printer;
        private readonly AbstractSyntaxTreeReflowGenerator reflowGenerator;

        public AstBuilderTests(ITestCase testCase)
        {
            this.testCase = testCase;
            printer = new AbstractSyntaxTreePrinter();
            reflowGenerator = new AbstractSyntaxTreeReflowGenerator();
        }

        [TestMethod]
        public void TestSimpleClass()
        {
            var node = testCase.TestCaseNode;
            Assert.IsNotNull(node);
            printer.Print(node);
            string generatedCode = reflowGenerator.GenerateCode(node);
            Console.WriteLine("Generated Code:\n" + generatedCode);
        }

        // Add more test methods here
    }
}