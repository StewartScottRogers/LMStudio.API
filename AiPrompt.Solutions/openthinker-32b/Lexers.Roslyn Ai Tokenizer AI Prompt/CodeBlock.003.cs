using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;

namespace RoslynAstTests
{
    [TestClass]
    public class SampleClassTests
    {
        [TestMethod]
        public void TestGenerateSyntaxTree()
        {
            string code = "public class SampleClass { public int SampleProperty { get; set; } }";
            
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilationUnit = (CSharpSyntaxNode)syntaxTree.GetRoot();
            
            Assert.IsNotNull(compilationUnit);
            Assert.AreEqual("SampleClass", compilationUnit.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>().First().Identifier.Text);
        }

        [TestMethod]
        public void TestPrettyPrint()
        {
            string code = "public class SampleClass { public int SampleProperty { get; set; } }";
            
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilationUnit = (CSharpSyntaxNode)syntaxTree.GetRoot();
            
            string prettyPrintedCode = compilationUnit.ToFullString();

            Assert.IsTrue(prettyPrintedCode.Contains("SampleClass"));
        }

        [TestMethod]
        public void TestReflow()
        {
            string code = "public class SampleClass { public int SampleProperty { get; set; } }";
            
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilationUnit = (CSharpSyntaxNode)syntaxTree.GetRoot();
            
            string reflowedCode = compilationUnit.ToFullString();

            Assert.IsTrue(reflowedCode.Contains("SampleClass"));
        }
    }
}