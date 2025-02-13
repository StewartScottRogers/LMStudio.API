using System;

namespace LexerLibrary
{
    public enum TokenType
    {
        Identifier,
        Number,
        String,
        Keyword,
        Operator,
        Punctuation,
        Whitespace,
        Newline,
        EndMarker
    }

To create a .NET 9.0 Solution for the provided grammar, we need to follow these steps:

1. **Initialize the Solution**: Create a new solution in Visual Studio 2022.
2. **Define Project Structure**:
   - Create separate files for each class, interface, enumeration, and record.
3. **Develop the Lexer, AST Nodes, and Pretty Printer**:
   - Implement the lexer to tokenize the input based on the given grammar.
   - Define all nodes in the Abstract Syntax Tree (AST).
   - Create a pretty printer to visualize the AST.
- **Unit Testing**: Write unit tests using Microsoft's Unit Test Framework.

Let's break down the solution into manageable steps:

1. **Initialize a new Solution in Visual Studio**:
    - Create a new .NET 9.0 Class Library project in Visual Studio 2022.

2. **Define the Project Structure**:
    - Separate files for each class, interface, enumeration, and record.

3. **Implement the Lexer**:
    - Create classes to represent different nodes in the Abstract Syntax Tree (AST).

4. **Generate the AST Pretty Printer**:
    - Implement a method to print the AST in a readable format.

5. **Unit Testing**:
   - Write unit tests for lexing the grammar and testing the pretty printer.

### Solution Structure

1. **Project Initialization**
2. **Define Class Library Structure**
3. **Implement Lexer**
4. **Generate Abstract Syntax Tree (AST)**
5. **Abstract Syntax Tree Pretty Printer**
6. **Unit Testing**

Let's break down the solution steps and implement each part:

### Step 1: Initialize a new Solution in Visual Studio

Create a new .NET 9.0 Class Library project in Visual Studio 2022.

### Step 2: Define the Project Structure

The project will have the following structure:
- `Lexer`
  - `Interfaces`
    - `ILexer.cs`
  - `Enums`
    - `TokenTypeEnum.cs`
  - `Records`
    - `StatementRecord.cs`
    - `TokenRecord.cs`
  - `Classes`
    - `LexerClass.cs`
    - `AbstractSyntaxTreePrinterClass.cs`
    - `NodeBase.cs`
      - `AssignmentNode.cs`
      - `CompoundStmtNode.cs`
      - `SimpleStmtNode.cs`
      - `FunctionDefNode.cs`
      - `IfStmtNode.cs`
      - `ClassDefNode.cs`
      - `WithStmtNode.cs`
      - `ForStmtNode.cs`
      - `TryStmtNode.cs`
      - `WhileStmtNode.cs`
      - `MatchStmtNode.cs`

To create a .NET 9.0 solution for lexing the provided grammar, we need to follow the specified coding style and structure. Below is a high-level overview of the steps and files that will be created:

### Solution Structure
1. **LexerLibrary**
   - **LexerNamespace**
     - **Enums** (e.g., TokenType)
     - **Interfaces** (e.g., ILexer)
     - **Records** (e.g., Token, LexerResultTuple)
     - **Classes** (e.g., Lexer)
     - **Methods and Properties**

### Project Structure

1. **Solution File**: `LexerSolution.sln`
2. **Project File**: `LexerLibrary.csproj`
3. **Class Files**:
   - `Lexer.cs`
   - `AstNode.cs` (Abstract Syntax Tree Node)
   - `AstPrettyPrinter.cs` (AST Pretty Printer)
4. **Unit Test Project File**: `LexerLibrary.Tests.csproj`
5. **Unit Test Class**: `LexerTests.cs`

Below is the implementation of the solution based on your requirements:

### Solution Structure