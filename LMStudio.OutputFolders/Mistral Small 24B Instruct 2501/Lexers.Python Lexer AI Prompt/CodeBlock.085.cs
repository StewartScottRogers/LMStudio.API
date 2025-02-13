using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public enum TokenType
    {
        // Define all token types based on the given grammar
        Identifier,
        Number,
        StringLiteral,
        Keyword,
        Operator,
        Punctuation,
        Whitespace,
        NewLine,
        EndMarker,
        InvalidToken
    }

Here is a complete .NET 9.0 Solution in C# that meets your requirements:

### Solution Structure

1. **Project Files:**
   - LexerSolution.sln
   - LexerLibrary.csproj
   - LexerLibrary.Tests.csproj

2. **Class and Interface Files:**
   - Token.cs
   - TokenType.cs
   - Lexer.cs
   - AbstractSyntaxTreeNode.cs
   - AbstractSyntaxTree.cs
   - PrettyPrinter.cs
   - ILexerTests.cs

Let's start by creating the solution structure in Visual Studio 2022.

### Solution Structure

1. **Solution Name**: LexerSolution
2. **Project Name**: LexerLibrary
3. **Files**:
    - `Lexer.cs`
    - `AbstractSyntaxTreePrinter.cs`
    - `AstNode.cs`
    - `IAstNode.cs`
    - `ILexer.cs`
    - `TokenType.cs` (Enumeration)
    - `Token.cs`

### Step-by-Step Solution

1. **Initialize a new Solution in Visual Studio**:
   - Create a new .NET 9.0 Class Library project.
   - Name the solution `LexerLibrary`.

2. **Define the Project Structure**:
   - Ensure each class, interface, enumeration, and record is in its own file.

3. **Implement the Lexer**:
   - Create classes for tokens, lexer, and AST nodes.
   - Use LINQ for tokenization.
   - Implement Fluent Interfaces where applicable.

4. **Implement the Pretty Printer**:
   - Create a class to pretty print the Abstract Syntax Tree (AST).

5. **Unit Testing**:
   - Write unit tests using Microsoft's Unit Test Framework.

Let's break down the solution steps and create the necessary files and code:

### Solution Structure