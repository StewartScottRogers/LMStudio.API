using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstGenerator;

namespace AstTests
{
    [TestClass]
    public class TestAstReflowGenerator
    {
        [TestMethod]
        public void TestGenerateCode()
        {
            var ast = new AbstractSyntaxTree { RootNode = "TestClass" };
            IAstReflowGenerator generator = new AstReflowGenerator();
            
            string expectedOutput = $"class {ast.RootNode} {{}}" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, generator.GenerateCode(ast));
        }
    }
}