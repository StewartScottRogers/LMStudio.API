using System;
using System.Collections.Generic;
using System.Linq;

namespace LexerLibrary
{
    public enum TokenType
    {
        Name,
        Number,
        StringLiteral,
        Newline,
        EndMarker,
        Indent,
        Dedent,
        LParen,
        RParen,
        LSquareBracket,
        RSquareBracket,
        LCurlyBrace,
        RCurlyBrace,
        Semicolon,
        Comma,
        Colon,
        Plus,
        Minus,
        Star,
        Slash,
        DoubleSlash,
        Percent,
        AtSign,
        Tilde,
        GreaterThan,
        LessThan,
        Equal,
        NotEqual,
        GreaterThanOrEqual,
        LessThanOrEqual,
        InKeyword,
        IsKeyword,
        IsNotKeyword,

To create a .NET 9.0 solution that includes a Lexer for the provided grammar, an Abstract Syntax Tree (AST) generator, and an AST Pretty Printer, we need to follow several steps. Below is a step-by-step guide along with the code implementation.

### Step 1: Initialize the Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new .NET Class Library project targeting .NET 9.0.
3. Name the project `LexerLibrary`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as follows:

1. **Nodes**
   - AbstractSyntaxNode.cs
   - StatementNode.cs
   - ExpressionNode.cs
   - CompoundStatementNode.cs
   - SimpleStatementNode.cs
   - AssignmentNode.cs
   - ReturnStatementNode.cs
   - RaiseStatementNode.cs
   - GlobalStatementNode.cs
   - NonLocalStatementNode.cs
   - DelStatementNode.cs
   - YieldStatementNode.cs
   - AssertStatementNode.cs
   - ImportNameNode.cs
   - ImportFromNode.cs

To create a .NET 9.0 Solution for lexing the given grammar and generating an Abstract Syntax Tree (AST), we need to follow the steps outlined in your prompt. Below is a high-level overview of the solution structure, along with some sample code snippets to get started.

### Solution Structure

1. **Class Library Project**
   - Create a new Class Library project in Visual Studio 2022.
   - Ensure all files are named appropriately and follow the naming conventions specified.

2. **File System Structure**
   - Separate files for each class, interface, enumeration, and record.

3. **Classes and Interfaces**
   - Define the necessary classes and interfaces to represent the grammar elements.
   - Implement methods for lexing, generating the Abstract Syntax Tree (AST), and pretty-printing the AST.

4. **Unit Tests**
   - Write comprehensive unit tests using Microsoft's Unit Test Framework.

### Solution Structure

1. **Solution Name**: LexerGrammar
2. **Projects**:
   - LexerGrammar.ClassLibrary
   - LexerGrammar.UnitTests

### Project Files

#### LexerGrammar.ClassLibrary

- **ClassFiles**
  - AbstractSyntaxTree.cs
  - AssignmentStatementNode.cs
  - AugAssignOperator.cs
  - CompoundStmtNode.cs
  - ExpressionNode.cs
  - FunctionDefNode.cs
  - IfStmtNode.cs
  - Lexer.cs
  - NamedExpressionNode.cs
  - ReturnStmtNode.cs
  - SimpleStmtNode.cs
  - StatementNode.cs

----------------------------------------------------------
Here is the basic structure for each file:

### File: Lexer.cs