using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynAiTokenizer.Models;
using RoslynAiTokenizer.Services;

namespace RoslynAiTokenizer.Tests
{
    [TestClass]
    public class AbstractSyntaxTreeReflowGeneratorTests
    {
        private readonly IAbstractSyntaxTreeParser parser = new AbstractSyntaxTreeParser();
        private readonly IAbstractSyntaxTreeReflowGenerator reflowGenerator = new AbstractSyntaxTreeReflowGenerator();

        [TestMethod]
        public void RegenerateCode_ShouldReturnNonEmptyString()
        {
            var sourceCode = "class Program { static void Main() {} }";
            var astNode = parser.ParseCode(sourceCode);
            var result = reflowGenerator.RegenerateCode(astNode);

            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
        }

        // Add more tests...
    }
}