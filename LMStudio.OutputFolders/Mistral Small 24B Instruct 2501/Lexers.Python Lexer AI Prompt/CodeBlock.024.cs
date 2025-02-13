using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lexer.Tests
{
    [TestClass]
    public class LexerTests
    {
        // Add 25 unit tests for lexing the Abstract Syntax Tree here.
        // Each test case should validate a different aspect of the lexing process.
        // Ensure to cover boundary conditions and edge cases.

        [TestMethod]
        public void TestSimpleAssignment()
        {
            var input = "x = 10";
            var tokens = Lexer.Lex(input);
            Assert.AreEqual("NAME", tokens[0].Type);
            Assert.AreEqual("=", tokens[1].Type);
            Assert.AreEqual("NUMBER", tokens[2].Type);
            // Additional assertions for the rest of the tokens
        }
    }
}

The structure and code provided will help in creating a Lexer, Abstract Syntax Tree (AST), and a Pretty Printer for the given grammar. Below is a step-by-step guide to create the solution.

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new Class Library project targeting .NET 9.0.
3. Name the project `LexerLibrary`.

### Step 2: Define Project Structure

Create separate files for each class, interface, enumeration, and record.

#### File Structure: