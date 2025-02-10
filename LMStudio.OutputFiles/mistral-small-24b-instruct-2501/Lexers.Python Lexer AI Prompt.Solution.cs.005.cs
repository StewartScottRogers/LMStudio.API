using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class AbstractSyntaxTree
    {
        private readonly List<StatementNode> statements = new();

        public void AddStatement(StatementNode statement)
        {
            Statements.Add(statement);
        }

        public IEnumerable<StatementNode> Statements => Statements.AsReadOnly();
    }
}

public static class LexerUtil
{
    public const char NewlineCharacter = '\n';

    // Method to convert a string of characters into a list of tokens.
    private static readonly List<string> TokenList;

    public static void InitializeTokenList()
    {
        TokenList.Clear();
        TokenList.AddRange(new[] { "compound_stmt", "simple_stmts", /* ... add all token names here */ });
    }

    // Method to get the next token from the input stream.
    private string GetNextToken(ref int position, readonly string input)
    {
        while (position < input.Length && char.IsWhiteSpace(input[position]))
        {
            position++;
        }

        if (position >= input.Length) return null;

        var start = position;
        if (char.IsLetterOrDigit(input[start]) || input[start] == '_')
        {
            // Read the entire identifier
            while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
            {
                position++;
            }
        }

I'll break down the solution into clear steps, adhering to your guidelines. Here’s a high-level overview of what we need to do:

1. **Initialize a new .NET Solution**: Create a new C# Class Library project in Visual Studio 2022.
2. **Define the Project Structure**: Ensure each class, interface, enumeration, and record is in its own file.
3. **Implement the Lexer**:
    - Generate a lexer for parsing the provided grammar.
    - Implement an Abstract Syntax Tree (AST) for representing the parsed code.
    - Create a pretty printer to visualize the AST.
4. **Unit Testing**: Write unit tests using Microsoft's Unit Test Framework to ensure the correctness of the lexer and parser.

Below is the implementation of the solution in C# following the provided guidelines:

### Solution Structure

1. **LexerLibrary** (Class Library)
   - `Lexer.cs`
   - `SyntaxNode.cs`
   - `PrettyPrinter.cs`
   - `ASTNodeTypes.cs` (Enumeration)
   - `TestLexer.cs` (Unit Tests)

**Step-by-Step Solution:**

### Step 1: Initialize a new .NET Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new solution named `PythonLexerSolution`.
3. Add a new Class Library project to the solution named `PythonLexerLibrary`.

Now, let's define the necessary classes, interfaces, and records for the lexer, abstract syntax tree (AST) pretty printer, and AST nodes. We will follow the coding style guidelines provided.

### Project Structure