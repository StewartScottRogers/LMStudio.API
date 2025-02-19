using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynAstTools;
using System.Threading.Tasks;

namespace RoslynAstTests
{
    [TestClass]
    public class AstUnitTests
    {
        [TestMethod]
        public async Task TestSimpleAddition()
        {
            string source = "5 + 3";
            var syntaxTree = Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ParseExpression(source);
            var printerOutput = AstPrettyPrinter.Print(syntaxTree);

            // Log the AST structure for debugging
            System.Diagnostics.Debug.WriteLine(printerOutput);

            string generatedCode = ReflowGenerator.Generate(syntaxTree);
            generatedCode += "; return " + generatedCode;

            dynamic result = await Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.EvaluateAsync(generatedCode);
            Assert.AreEqual(8, (int)result);
        }

        // Add 24 more test methods for various scenarios
    }
}