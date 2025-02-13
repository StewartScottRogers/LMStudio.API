using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerSolution
{
    // Define the lexing result tuple for returning multiple values from a method.
    public class LexResultTuple
    {
        public string Token { get; set; }
        public string Value { get; set; }

        public LexResultTuple(string token, string value)
        {
            this.Token = token;
            this.Value = value;
        }
    }

To create the .NET 9.0 Solution for lexing the given grammar and generating an Abstract Syntax Tree (AST) Pretty Printer in C#, follow these steps:

### Step 1: Initialize a New Solution

1. Open Visual Studio 2022.
2. Create a new solution and name it `LexerSolution`.
3. Add a Class Library project named `LexerLibrary`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as follows:

- **Classes**:
    - `Lexer.cs`
    - `NodeVisitor.cs`
    - `PrettyPrinter.cs`

- **Interfaces**:
    - `INode.cs`

- **Records**:
    - `TokenRecord.cs`
    - `SyntaxTreeNodeRecord.cs`

### File Structure