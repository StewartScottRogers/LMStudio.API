using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstLexer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AstPrettyPrinter;
using AstReflowGenerator;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class AstLexerTests
    {
        private readonly AbstractSyntaxTreeLexer abstractSyntaxTreeLexer = new AbstractSyntaxTreeLexer();
        private readonly AbstractSyntaxTreePrettyPrinter abstractSyntaxTreePrettyPrinter = new AbstractSyntaxTreePrettyPrinter();
        private readonly AbstractSyntaxTreeReflowGenerator abstractSyntaxTreeReflowGenerator = new AbstractSyntaxTreeReflowGenerator();

        [TestMethod]
        public void TestLexIdentifier()
        {
            var sourceCode = "int myVariable;";
            var tree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = tree.GetRoot();
            var tokens = abstractSyntaxTreeLexer.Lex(root);

            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual("Identifier", tokens[0].Type);
            Assert.AreEqual("myVariable", tokens[0].Value);
        }

        [TestMethod]
        public void TestLexLiteral()
        {
            var sourceCode = "int x = 10;";
            var tree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = tree.GetRoot();
            var tokens = abstractSyntaxTreeLexer.Lex(root);

            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual("Literal", tokens[0].Type);
            Assert.AreEqual("10", tokens[0].Value);
        }

        // Add 23 more unit tests here to cover various AST nodes and lexing scenarios.
        // Examples: Lexing operators, keywords, expressions, statements, etc.
        // Use Assert.AreEqual or other appropriate assertions to verify the expected token types and values.

        [TestMethod]
        public void TestLexSimpleAssignment()
        {
            var sourceCode = "int a = 5;";
            var tree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = tree.GetRoot();
            var tokens = abstractSyntaxTreeLexer.Lex(root);

            Assert.AreEqual(2, tokens.Count);
            Assert.AreEqual("Identifier", tokens[0].Type);
            Assert.AreEqual("a", tokens[0].Value);
            Assert.AreEqual("Literal", tokens[1].Type);
            Assert.AreEqual("5", tokens[1].Value);
        }

        [TestMethod]
        public void TestPrettyPrintAndReflow()
        {
            var sourceCode = "int x = 10;";
            var tree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = tree.GetRoot();

            string prettyPrintedAst = abstractSyntaxTreePrettyPrinter.Print(root);
            Console.WriteLine("Pretty Printed AST:\n" + prettyPrintedAst); // Output for inspection

            string reflowedCode = abstractSyntaxTreeReflowGenerator.GenerateCode(root);
            Console.WriteLine("Reflowed Code:\n" + reflowedCode); // Output for inspection

            Assert.AreEqual(sourceCode, reflowedCode); // Verify code is preserved
        }
    }
}