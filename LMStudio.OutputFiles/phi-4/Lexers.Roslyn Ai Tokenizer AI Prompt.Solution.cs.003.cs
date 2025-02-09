// AstGeneratorTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RoslynAiTokenizer.Tests
{
    [TestClass]
    public class AstGeneratorTests
    {
        [TestMethod]
        public void GenerateAst_ShouldNotBeNull()
        {
            var sourceCode = "class Test {}";
            var generator = new AstGenerator(sourceCode);
            var ast = generator.GenerateAst();

            Assert.IsNotNull(ast);
        }

        // Additional tests for AST generation, printing, and reflow
    }
}