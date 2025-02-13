using System;
using System.IO;

namespace PythonLexer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the lexer and pretty printer.
            string sourceCode = @"def exampleFunction():
                print('Hello, World!')";

            var lexerOutputTuple = Lexer.Lex(sourceCode);
            Console.WriteLine("Lexing Output:");
            foreach (var token in lexerOutputTuple.TokenList)
            {
                Console.WriteLine(token.ToString());
            }

            var astOutputTuple = AbstractSyntaxTreeBuilder.BuildAbstractSyntaxTree(lexerOutputTuple);
            Console.WriteLine("\nAbstract Syntax Tree:");
            AbstractSyntaxTreePrinter.Print(astOutputTuple);

            // Unit Tests
            UnitTestRunner.RunTests();
        }
    }
}

namespace LexerLibrary.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void TestLexingSimpleStatement()
        {
            // Arrange
            var input = "x = 1; y = 2";
            var expectedTokens = new List<string>
            {
                "NAME", "ASSIGN", "NUMBER", "SEMICOLON",
                "NAME", "ASSIGN", "NUMBER"
            };

            // Act
            var lexerResultTuple = Lexer.Lex(inputCode);

            // Assert
            CollectionAssert.AreEqual(expectedTokens, lexerResultTuple.Tokens);
        }

        [TestMethod]
        public void TestLexingOfEmptyInput()
        {
            // Arrange
            string inputCode = "";
            List<string> expectedTokens = new List<string>();

            // Act
            var (tokensList, errorsList) = Lexer.Lex(inputCode);

            // Assert
            CollectionAssert.AreEqual(expectedTokens, tokensList);
            CollectionAssert.IsEmpty(errorsList);
        }
    }

    [TestMethod]
    public void TestLexStatementNewline()
    {
        // Arrange
        readonly string input = "\n\n";

        // Act
        var resultTuple = Lexer.Lex(input);

        // Assert
        var statementsTuple = resultTuple.Statements;
        var errorsTuple = resultTuple.Errors;

        Assert.IsTrue(statementsTuple.Length == 0, "Expected no statements.");
        Assert.IsTrue(errorsTuple.Length == 0, "Expected no errors.");

# Solution Structure

## Project: PythonLexer
- **PythonLexer**: Class Library containing the lexer implementation.
- **TestProject**: Unit tests for the lexer.

### Files

#### PythonLexer
1. **Token.cs** - Definition of token types.
2. **Lexer.cs** - Lexer class to tokenize input.
3. **AbstractSyntaxTree.cs** - Abstract Syntax Tree (AST) nodes.
4. **AstPrettyPrinter.cs** - Pretty printer for AST.

#### Tests

- Unit tests for lexing the Abstract Syntax Tree.
- 25 Unit Tests in total.

### Solution Structure

1. **Solution**: LexerSolution
   - **Projects**:
     - **LexerLibrary** (Class Library)
       - **Classes**:
         - `Lexer.cs`
         - `AbstractSyntaxTreeNode.cs`
         - `PrettyPrinter.cs`
         - `StatementNode.cs`
         - `SimpleStmtNode.cs`
         - `CompoundStmtNode.cs`
         - `AssignmentNode.cs`
         - `ReturnStmtNode.cs`
         - `RaiseStmtNode.cs`
         - `GlobalStmtNode.cs`
         - `NonlocalStmtNode.cs`
         - `DelStmtNode.cs`
         - `YieldStmtNode.cs`
         - `AssertStmtNode.cs`
         - `ImportStmtNode.cs`
         - `FunctionDefNode.cs`
         - `ClassDefNode.cs`
         - `IfStmtNode.cs`
         - `WhileStmtNode.cs`
         - `ForStmtNode.cs`
         - `WithStmtNode.cs`
         - `TryStmtNode.cs`
         - `MatchStmtNode.cs`

Below is a .NET 9.0 solution that meets the specified requirements. The solution includes a Class Library for lexing the given grammar, generating an Abstract Syntax Tree (AST), and a Pretty Printer for the AST. Additionally, it includes unit tests using Microsoft's Unit Test Framework.

### Solution Structure

1. **Class Library Project**
   - `Lexer`
     - `Lexer.cs`
   - `Ast`
     - `AstNode.cs`
     - `StatementNodes`
       - `CompoundStatementNode.cs`
       - `SimpleStatementNode.cs`
     - `ExpressionNodes`
       - `AssignmentExpressionNode.cs`
       - `ReturnExpressionNode.cs`
     - `ImportNodes`
       - `ImportNameNode.cs`
       - `ImportFromNode.cs`
     - `ControlFlowNodes`
       - `IfStmtNode.cs`
       - `WhileStmtNode.cs`
       - `ForStmtNode.cs`
       - `WithStmtNode.cs`
       - `TryExceptFinallyBlock.cs`
       - `MatchStmtNode.cs`


To create a .NET 9.0 Solution for lexing the provided grammar and generating an Abstract Syntax Tree (AST), we need to follow the specified coding style, library usage, and programming constructs. Below is a step-by-step guide to initialize the solution in Visual Studio 2022:

### Step 1: Initialize a New Solution

1. Open Visual Studio 2022.
2. Create a new Class Library project.
3. Name the project `LexerLibrary`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as specified in the grammar.

#### File: `AstNode.cs`