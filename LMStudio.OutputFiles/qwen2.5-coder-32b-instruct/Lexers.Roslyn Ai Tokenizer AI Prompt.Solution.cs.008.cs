using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynAiTokenizer.Models;
using RoslynAiTokenizer.Services;

namespace RoslynAiTokenizer.Tests
{
    [TestClass]
    public class AbstractSyntaxTreePrettyPrinterTests
    {
        private readonly IAbstractSyntaxTreeParser parser = new AbstractSyntaxTreeParser();
        private readonly IAbstractSyntaxTreePrettyPrinter prettyPrinter = new AbstractSyntaxTreePrettyPrinter();

        [TestMethod]
        public void PrettyPrint_ShouldReturnNonEmptyString()
        {
            var sourceCode = "class Program { static void Main() {} }";
            var astNode = parser.ParseCode(sourceCode);
            var result = prettyPrinter.PrettyPrint(astNode);

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        // Add more tests...
    }
}