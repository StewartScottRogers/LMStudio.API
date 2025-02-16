using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstPrinter;

namespace UnitTests
{
    [TestClass]
    public class AstLexerTests
    {
        private static readonly string TestCode = "public class Example { public int Method() { return 42; } }";

        [TestMethod]
        public void TestAstPrettyPrint()
        {
            var tree = CSharpSyntaxTree.ParseText(TestCode);
            var root = tree.GetRoot();

            var prettyPrinter = AstPrettyPrinter.PrintAst(root);

            // Display the AST
            Console.WriteLine(prettyPrinter);

            Assert.IsTrue(!string.IsNullOrEmpty(prettyPrinter));
        }

        [TestMethod]
        public void TestAstReflowGenerate()
        {
            var tree = CSharpSyntaxTree.ParseText(TestCode);
            var root = tree.GetRoot();

            var reflowGenerator = AstReflowGenerator.GenerateCode(root);

            // Display the generated code
            Console.WriteLine(reflowGenerator);

            Assert.IsTrue(!string.IsNullOrEmpty(reflowGenerator));
        }

        // Add more tests as required...
    }
}