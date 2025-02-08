using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynAiTokenizer.Models;
using RoslynAiTokenizer.Services;

namespace RoslynAiTokenizer.Tests
{
    [TestClass]
    public class AbstractSyntaxTreeParserTests
    {
        private readonly IAbstractSyntaxTreeParser parser = new AbstractSyntaxTreeParser();

        [TestMethod]
        public void ParseCode_ShouldReturnNonNullRoot()
        {
            var sourceCode = "class Program { static void Main() {} }";
            var astNode = parser.ParseCode(sourceCode);

            Assert.IsNotNull(astNode);
        }

        // Add more tests...
    }
}