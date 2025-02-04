using Compiler.CSharp.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Compiler.CSharp.UnitTests
{
    [TestClass]
    public sealed class CShardUnitTests
    {
        [TestMethod]
        public void RoslynCsCompilerUnitTest()
        {
            string csCode
                =
                "using Microsoft.CodeAnalysis;\r\n" +
                "using Microsoft.CodeAnalysis.CSharp;\r\n" +
                "\r\n" +
                "namespace Compiler.CSharp\r\n" +
                "{\r\n" +
                "    public static class RoslynCsCompiler\r\n" +
                "    {\r\n" +
                "        public static SyntaxTree CompileSyntaxTree(this string csCode)\r\n" +
                "        {\r\n" +
                "            SyntaxTree syntaxTree\r\n" +
                "                = CSharpSyntaxTree.ParseText(csCode);\r\n" +
                "\r\n" +
                "            return syntaxTree;\r\n" +
                "        }\r\n" +
                "    }\r\n" +
                "}\r\n";

            SyntaxTree syntaxTree
                = csCode.CompileSyntaxTree();

            string formattedSyntaxTree
               = syntaxTree.GetRoot()
                   .ToFormattedSyntaxTree().Trim();

            Console.WriteLine(formattedSyntaxTree);
        }
    }
}
