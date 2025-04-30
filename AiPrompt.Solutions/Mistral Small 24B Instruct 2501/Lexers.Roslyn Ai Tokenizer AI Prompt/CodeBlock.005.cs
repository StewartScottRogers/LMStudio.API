using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoslynAstTests
{
    [TestClass]
    public class LexingTests
    {
        private readonly ICodeGenerator astGenerator = new AstGenerator();

        [TestMethod]
        public void TestSimpleClass()
        {
            var code = "class Sample { public int Id { get; set; } }";
            var syntaxTree = astGenerator.GenerateAst(code);
            
            Assert.IsNotNull(syntaxTree);
        }

        // Add more tests as required
    }
}