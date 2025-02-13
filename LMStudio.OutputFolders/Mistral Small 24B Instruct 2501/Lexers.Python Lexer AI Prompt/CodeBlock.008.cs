using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer : ILexer
    {
        private readonly string Input;
        private int Position;

        public Lexer(string input)
        {
            Input = input ?? throw new ArgumentNullException(nameof(input));
            Position = 0;
        }

        public void Tokenize()
        {
            // Implement the tokenization logic here
        }
    }

To create a complete .NET 9.0 Solution that includes a Class Library for lexing the given grammar, generating an Abstract Syntax Tree (AST), and implementing a Pretty Printer for the AST, follow these steps:

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new .NET 9.0 Class Library project named `LexerLibrary`.

### Step 2: Define Project Structure

Create separate files for each class, interface, enumeration, and record as specified:

- `Token.cs`
- `AbstractSyntaxTreeNode.cs`
- `StatementNode.cs`
- `SimpleStmtNode.cs`
- `CompoundStmtNode.cs`
- `AssignmentNode.cs`
- `ReturnNode.cs`
- `RaiseNode.cs`
- `GlobalNode.cs`
- `NonlocalNode.cs`
- `DelNode.cs`
- `YieldNode.cs`
- `AssertNode.cs`
- `ImportNameNode.cs`
- `ImportFromNode.cs`
- **FunctionDefinitions** : FunctionDefRawNode.cs
- **ClassDefinitions** : ClassDefRawNode.cs

Let's break down the solution into manageable steps and create the necessary files and code.

### Step 1: Initialize a new Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new .NET 9.0 Class Library project named `LexerLibrary`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record.

#### File: AbstractSyntaxTree.cs