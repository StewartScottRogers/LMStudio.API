using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASTGeneratorTests
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly CSharpParseOptions ParseOptions = new(LanguageVersion.Preview, DocumentationMode.Diagnose);

        [TestMethod]
        public void TestMethod1()
        {
            var sourceText = SourceText.From(@"using System;
                                              class Program { static void Main() { Console.WriteLine("Hello World!"); } }");

            var syntaxTree = SyntaxFactory.ParseSyntaxTree(sourceText, ParseOptions);
            
            Assert.IsNotNull(syntaxTree);
        }
    }
}