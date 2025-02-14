using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstGenerator;

namespace AstTests
{
    [TestClass]
    public class TestAstPrettyPrinter
    {
        [TestMethod]
        public void TestPrint()
        {
            var ast = new AbstractSyntaxTree { RootNode = "TestClass" };
            IAstPrinter printer = new AstPrettyPrinter();
            
            // Redirect console output to capture it for testing.
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                
                printer.Print(ast);
                
                string expectedOutput = $"Root Node: {ast.RootNode}" + Environment.NewLine;
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}